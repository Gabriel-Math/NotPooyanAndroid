using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject menu;
	Controller pl;

	public Text highScoreText;

	void Start() {

		if(highScoreText != null)
			highScoreText.text = "Highscore: " + PlayerPrefs.GetFloat ("Highscore").ToString();

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
		}
	}

	void Update() {
		if (pl != null) {
			if (pl.life == 0) {
				GameOver ();
			}
		}
	}

	void GameOver() {
		menu.SetActive (true);
	}
		
	public void Play() {
		SceneManager.LoadScene ("Jogo");
	}

	public void Quit() {
		Application.Quit();
	}

	public void toMenu() {
		SceneManager.LoadScene ("Menu");
	}

	public void Restart() {
		SceneManager.LoadScene ("Jogo");
	}
}
