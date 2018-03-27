using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartBar : MonoBehaviour {

	public Sprite[] heartSprites;

	public Image heartUI;

	Controller pl;

	void Start () {
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		heartUI.sprite = heartSprites[pl.life];
	}
}
