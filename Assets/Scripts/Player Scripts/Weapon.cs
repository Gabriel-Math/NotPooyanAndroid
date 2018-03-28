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
        if (Input.touchCount > 0)
        {
            if (isShooting)
            {
                count += Time.deltaTime;
                Touch touch = Input.GetTouch(0);
                #region Semi-auto
                if (touch.phase == TouchPhase.Ended && count <= 0.3f)
                {
                    if (Time.time > timeToFire)
                    {
                        timeToFire = Time.time + 1 / fireRateSemi;
                        Shoot();
                    }
                    return;
                }
				#endregion
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isShooting = true;
                }
            }
        }
        else
        {
            count = 0;
            isShooting = false;
        }
        #endregion
    }

	void Shoot (){
		
		GameObject Clone;

		Clone = (Instantiate(projectilePrefab, firePoint.transform.position,transform.rotation)) as GameObject;
		Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(downForce, upForce));
		Destroy (Clone.gameObject, lifeTime);

	}

}