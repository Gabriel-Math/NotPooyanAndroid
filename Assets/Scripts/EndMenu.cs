using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {

	public static bool gameOver = false;

	public GameObject pauseMenuUI;

	Controller pl;

	void Start() {
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
	}

	void Update() {
		if (pl.gameOver == true) {
			GameOver ();
		}
	}

	public void Restart() {
		pauseMenuUI.SetActive (false);
		SceneManager.LoadScene ("Jogo");
	}

	public void GameOver() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
	}

	public void Menu() {
		SceneManager.LoadScene ("Menu");
	}

	public void Play() {
		SceneManager.LoadScene ("Jogo");
	}

	public void Quit() {
		Application.Quit();
	}
}
