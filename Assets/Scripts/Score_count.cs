using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_count : MonoBehaviour {

	public int score = 0;
	public int highscore = 0;

	public Text scorePoints;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Score")) {
			if (SceneManager.GetActiveScene().name == "Jogo") {
				PlayerPrefs.DeleteKey ("Score");
				score = 0;
			} else {
				score = PlayerPrefs.GetInt ("Score");
			}
		}

		if (PlayerPrefs.HasKey ("Highscore")) {
			highscore = PlayerPrefs.GetInt ("Highscore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(scorePoints != null)
			scorePoints.text = score.ToString();
	}
}
