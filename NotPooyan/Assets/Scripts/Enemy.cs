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

	void Start() {
		obj = this.GetComponent<SpriteRenderer> ();
		life = health[Random.Range (0, 3)];
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}

	void Update() {
		if (life <= 0) {
			Destroy (this.gameObject);
			pl.score += 1;
		}
		if (life == 10) {
			obj.sprite = easy;
		}
		if (life == 20) {
			obj.sprite = normal;
		}
		if (life == 30) {
			obj.sprite = hard;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Projectile") 
		{
			life -= 10;
			Destroy (other.gameObject);
		}
		else
		if (other.gameObject.tag == "Underground") 
		{
			pl.life -= 1;
			Destroy (this.gameObject);
		}
	}
}
