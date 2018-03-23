using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public float movementSpeed;
	Weapon weapon;

	public int score = 0;
	public int life;

	public Text scorePoints;
	double halfScreenTopDown;

	public float maxHeight;
	public float minHeight;

	void Start() {
		weapon = GetComponentInChildren<Weapon> ();
		life = 3;
		Time.timeScale = 1f;
	}

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && weapon.isShooting == false) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint((Input.GetTouch (0).position)), Vector2.zero);
			if(hit.collider.tag == "Player") {
				Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
				hit.transform.position = new Vector3(hit.transform.position.x, touchPosition.y, hit.transform.position.z);

				if (hit.transform.position.y >= maxHeight) {
					hit.transform.position = new Vector3(hit.transform.position.x, maxHeight, hit.transform.position.z);
				}
				if (hit.transform.position.y <= minHeight) {
					hit.transform.position = new Vector3(hit.transform.position.x, minHeight, hit.transform.position.z);
				}
			}
		}

		if (life != 0) {
			scorePoints.text = score.ToString ();
		} else {
			scorePoints.text = "Game Over: " + score.ToString();
			Time.timeScale = 0;
		}
	}
}

