using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float movementSpeed;
	public bool gameOver;
	public int life = 5;

	double halfScreenTopDown;

	public float maxHeight;
	public float minHeight;

	Score_count sc;

	void Start() {
		sc = GameObject.FindGameObjectWithTag ("GM").GetComponent<Score_count> ();
		gameOver = false;
		Time.timeScale = 1f;
	}

	void Update() {
		if (gameOver == false || PauseMenu.GameIsPaused == false) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);
				if (hit.collider.tag == "Player") {
					Vector2 touchPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
					hit.transform.position = new Vector3 (hit.transform.position.x, touchPosition.y, hit.transform.position.z);

					if (hit.transform.position.y >= maxHeight) {
						hit.transform.position = new Vector3 (hit.transform.position.x, maxHeight, hit.transform.position.z);
					}
					if (hit.transform.position.y <= minHeight) {
						hit.transform.position = new Vector3 (hit.transform.position.x, minHeight, hit.transform.position.z);
					}
				}
			}
		}
		life = 5;
			
		if (life == 0) {
			SaveScore ();
			gameOver = true;
		}
	}

	void SaveScore() {
		PlayerPrefs.SetInt ("Score", sc.score);

		if (PlayerPrefs.HasKey ("Highscore")) {
			if (PlayerPrefs.GetInt ("Highscore") < sc.score) {
				PlayerPrefs.SetInt ("Highscore", sc.score);
			}
		} else {
			PlayerPrefs.SetInt ("Highscore", sc.score);
		}
	}
}
	

