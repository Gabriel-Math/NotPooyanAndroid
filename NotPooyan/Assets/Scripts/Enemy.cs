using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	int[] health = new int[] {10, 20, 30};
	int life;

	SpriteRenderer obj;
	public Sprite easy;
	public Sprite normal;
	public Sprite hard;

	Controller pl;

	float fallSpeed;

	void Start() {
		obj = this.GetComponent<SpriteRenderer> ();
		life = health[Random.Range (0, 3)];
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}

	void Update() {

		transform.Translate (new Vector3(0, -fallSpeed, 0) * Time.deltaTime);

		if (transform.position.y < -1) { 
			pl.life -= 1;
			Destroy (this.gameObject);
		}

		if (life <= 0) {
			Destroy (this.gameObject);
			pl.score += 1;
		}
		if (life == 10) {
			obj.sprite = easy;
			fallSpeed = 3f;
		}
		if (life == 20) {
			obj.sprite = normal;
			fallSpeed = 2f;
		}
		if (life == 30) {
			obj.sprite = hard;
			fallSpeed = 1f;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Projectile") 
		{
			life -= 10;
			Destroy (other.gameObject);
		}
	}
}
