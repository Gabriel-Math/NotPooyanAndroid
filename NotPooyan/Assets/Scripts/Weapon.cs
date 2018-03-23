using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	public GameObject projectilePrefab;

	float lifeTime = 3f;

	public float fireRate = 0;
	public float upForce = 0f;
	public float downForce = -800f;
	public bool isShooting = false;
	public float count = 0;

	float timeToFire = 0;
	public Transform firePoint;

	void Update() {

		#region Mobile Controls
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Stationary) {
				isShooting = true;
				count = Time.deltaTime;
				if(count < 0.5f) {
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
			count = 0;
			isShooting = false;
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


