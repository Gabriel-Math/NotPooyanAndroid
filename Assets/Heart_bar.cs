using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Heart_bar : MonoBehaviour {

	public Sprite[] heartSprites;

	private Controller pl;

	void Start() {
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}
}
