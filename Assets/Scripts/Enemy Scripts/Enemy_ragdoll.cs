using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ragdoll : MonoBehaviour {

	public GameObject ballon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ballon == null) {
			this.gameObject.AddComponent<Rigidbody2D> ();
			this.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(-10f,0f), Random.Range(10f,0f)));;
			if (transform.position.y < 1f || transform.position.x < 2.5f) { 
				Destroy (this.gameObject);
			}
		}
	}
}