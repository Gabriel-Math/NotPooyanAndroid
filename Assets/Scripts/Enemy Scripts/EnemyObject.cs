using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

	public float fallSpeed;

	public GameObject ballon_skin;
	public GameObject enemy_skin;


	void Update () {
		transform.Translate (new Vector3(0, -fallSpeed, 0) * Time.deltaTime);

		if (transform.position.y < -3f) { 
			Destroy (this.gameObject);
		}
			
		if (ballon_skin == null) {
			enemy_skin.gameObject.AddComponent<Rigidbody2D> ();
			enemy_skin.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(-3f,3f), Random.Range(-10f,0f)));;
		}
	}
}
