using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	public GameObject projectilePrefab;

	float lifeTime = 3f;

	public float fireRateAuto = 0;
	public float fireRateSemi = 0;
	public float upForce = 0f;
	public float downForce = -800f;
	public bool isShooting = false;
	public float count = 0;

	float timeToFire = 0;
	public Transform firePoint;

	void Update() {

		#region Mobile Controls
		if (Input.touchCount > 0) {
			count += Time.deltaTime;

			#region Auto-fire
			if (Input.GetTouch (0).phase == TouchPhase.Stationary && count >= 0.5f) {
				isShooting = true;
				if (fireRateAuto == 0) {
					Shoot ();
				} else {
					if (Time.time > timeToFire) {
						timeToFire = Time.time + 1 / fireRateAuto;
						Shoot ();
					}
				}
				isShooting = false;
			}
			#endregion

			#region Semi-auto
			if(Input.GetTouch(0).phase == TouchPhase.Ended && count <= 0.3f) {
				isShooting = true;
				if (Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRateSemi;
					Shoot ();
				}
			}
			isShooting = false;
			#endregion
		} else
			count = 0;
		#endregion
	}

	void Shoot (){
		
		GameObject Clone;

		Clone = (Instantiate(projectilePrefab, firePoint.transform.position,transform.rotation)) as GameObject;
		Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(downForce, upForce));
		Destroy (Clone.gameObject, lifeTime);

	}

}