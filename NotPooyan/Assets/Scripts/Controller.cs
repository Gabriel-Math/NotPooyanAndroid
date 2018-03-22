using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public float movementSpeed;
	CharacterController controller;

	public int score = 0;
	public int life;

	public Text scorePoints;
	double halfScreenTopDown;

	void Start() {
		controller = GetComponent<CharacterController>();
		life = 3;
		halfScreenTopDown = Screen.height / 2.0;
	}

	void Update() {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			Vector2 touchPosition = Input.GetTouch (0).position;

			if (touchPosition.y > halfScreenTopDown) {
				controller.Move (Vector2.up * movementSpeed * Time.deltaTime);
			} else if (touchPosition.y < halfScreenTopDown) {
				controller.Move (Vector2.down * movementSpeed * Time.deltaTime);
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchPosition = Input.GetTouch (0).position;

			if (touchPosition.y > halfScreenTopDown) {
				controller.Move (Vector2.up * movementSpeed * Time.deltaTime);
			} else if (touchPosition.y < halfScreenTopDown) {
				controller.Move (Vector2.down * movementSpeed * Time.deltaTime);
			}
		}


		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			controller.Move (Vector2.up * movementSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			controller.Move (Vector2.down * movementSpeed * Time.deltaTime);
		}

		if (life != 0) {
			scorePoints.text = score.ToString ();
		} else {
			print ("Game over");
			scorePoints.text = "Game Over: " + score.ToString();
			Time.timeScale = 0;
		}
	}
}

