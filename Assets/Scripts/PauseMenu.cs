using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	void Update() {
		if (Input.GetKey (KeyCode.Escape)) {
			if (!GameIsPaused) {
				Pause ();
			}
		}
	}

	public void Resume() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Menu() {
		GameIsPaused = false;
		SceneManager.LoadScene ("Menu");
	}

	public void Play() {
		SceneManager.LoadScene ("Jogo");
	}

	public void CharacterSelect() {
		SceneManager.LoadScene ("CharacterSelection");
	}

	public void Quit() {
		Application.Quit();
	}
}
