using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;
	public float posX1;
	public float posX2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (posX1, posX2);
			whereToSpawn = new Vector2 (randX, transform.position.y);
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}
		
	}
}
