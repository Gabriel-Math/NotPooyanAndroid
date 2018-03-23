using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject endMenu;
	Controller pl;

	void Start() {
		endMenu.SetActive (false);
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}

	void Update() {
		if (pl.life == 0) {
			GameOver ();
		}
	}

	void GameOver() {
		endMenu.SetActive (true);
	}

	public void Restart() {
		SceneManager.LoadScene ("Scene");
	}
}
