using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_spawn : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Enemy
    {
        public Transform enemyPrefab;
        [Range(0,100)]
        public float probability = 0;
    }

	[System.Serializable]
	public class Wave {
		public string name;
		public Enemy[] enemies;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	float value;
	int enemyChosen;

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;

	private float searchCountdown = 1f;

	public SpawnState state = SpawnState.COUNTING;

	void Start() {
        waveCountdown = timeBetweenWaves;
    }

	void Update() {

		if (state == SpawnState.WAITING) {
			if (!EnemyIsAlive ()) {
				WaveCompleted ();
			} else {
				return; 
			}
		}

		if (waveCountdown <= 0) {
			if (state != SpawnState.SPAWNING) {
				StartCoroutine (SpawnWave(waves[nextWave]));
			}
		} else {
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted() {

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) {
			nextWave = 0;
		} else {
			nextWave++;
		}
	}

	bool EnemyIsAlive() {

		searchCountdown -= Time.deltaTime;
		if(searchCountdown <= 0f) {
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag ("Enemy") == null) {
				return false;
			}
		}

		return true;
	}

	IEnumerator SpawnWave (Wave _wave) {
		state = SpawnState.SPAWNING;

		if(_wave.enemies.Length == 1)
			_wave.enemies[0].probability = 100f;

		for (int i = 0; i < _wave.count; i++) {
			int ran = Random.Range(0, 100);

			value = 0;
			for(int j = 0; j < _wave.enemies.Length; j++) {
				value += _wave.enemies[j].probability;
				if (ran < value) {
					enemyChosen = j;
					break;
				}
			}

			SpawnEnemy (_wave.enemies[enemyChosen].enemyPrefab);
			yield return new WaitForSeconds (1f / _wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy) {

		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate (_enemy, _sp.position, _sp.rotation);
	}
}
