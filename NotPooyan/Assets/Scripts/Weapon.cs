using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	public GameObject projectilePrefab;

	float lifeTime = 3f;

	public float fireRate = 0;
	public float upForce = 0f;
	public float downForce = -800f;

	double halfScreen;

	float timeToFire = 0;
	public Transform firePoint;

	void Start() {
		halfScreen = Screen.width / 2.0;
	}

	void Update() {

		#region Mobile Controls
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector2 touchPosition = Input.GetTouch (0).position;

			if (touchPosition.x < halfScreen) {
				if (fireRate == 0) {
					Shoot ();
				} else {
					if (Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRate;
						Shoot ();
					}
				}
			}
		}
		#endregion
			
		#region Desktop Controls
		if (fireRate == 0) {
			if(Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if(Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
		#endregion
	}

	void Shoot ()
	{
		GameObject Clone;

		Clone = (Instantiate(projectilePrefab, firePoint.transform.position,transform.rotation)) as GameObject;
		Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(downForce, upForce));
		Destroy (Clone.gameObject, lifeTime);
	}

}
