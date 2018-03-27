using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

	public float fallSpeed;

	void Update () {
		transform.Translate (new Vector3(0, -fallSpeed, 0) * Time.deltaTime);

		if (transform.position.y < -3f) { 
			Destroy (this.gameObject);
		}
	}
}
