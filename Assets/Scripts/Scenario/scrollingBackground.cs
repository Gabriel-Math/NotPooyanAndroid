using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour {

	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 offset = new Vector2 (Time.time * speed, 0);

        //GetComponent<Renderer>().material.mainTextureOffset = offset;
        GetComponent<SpriteRenderer>().size += new Vector2(Time.deltaTime * speed, 0);//material.mainTextureOffset = offset;
        //GetComponent<SpriteRenderer>().sortingOrder = valor;
    }
}
