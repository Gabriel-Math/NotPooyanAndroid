using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	int health;

	SpriteRenderer obj;
	public Sprite easy;
	public Sprite normal;
	public Sprite hard;

	Controller pl;
	EnemyObject en;
	Score_count sc;

	void Start() {
		sc = GameObject.FindGameObjectWithTag ("GM").GetComponent<Score_count> ();
		en = gameObject.GetComponentInParent<EnemyObject> ();
		obj = GetComponent<SpriteRenderer> ();
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
		health = en.health;
	}

	void Update() {

		if (transform.position.y < -1) { 
			pl.life -= 1;
			Destroy (this.gameObject);
		}

		if (health <= 0) {
			Destroy (this.gameObject);
			sc.score += 1;
		}
		if (health == 10) {
			obj.sprite = easy;
			en.fallSpeed = 1.5f;
		}
		if (health == 20) {
			obj.sprite = normal;
			en.fallSpeed = 1f;
		}
		if (health == 30) {
			obj.sprite = hard;
			en.fallSpeed = 0.5f;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Projectile") 
		{
			health -= 10;
			Destroy (other.gameObject);
		}
	}
}
