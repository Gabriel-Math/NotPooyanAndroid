using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rope : MonoBehaviour {

	GameObject pl;
	GameObject rope;
	Vector2 vetor;
	float y;

	void Start() {
		pl = GameObject.FindGameObjectWithTag ("Player");
		rope = this.gameObject;
		vetor = rope.transform.position;
	}

	void Update() {
		y = (vetor.y - pl.transform.position.y);
		rope.transform.localPosition = new Vector3(vetor.x, vetor.y - y/2, 0);
		rope.transform.localScale = new Vector3(rope.transform.localScale.x, y/4+0.3f, 0);
	}
}
