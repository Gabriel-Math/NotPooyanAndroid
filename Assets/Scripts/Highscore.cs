using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Highscore : MonoBehaviour {

	public Text highScoreText;
	public Score_count sc;

	void Start() {
		highScoreText.text = "Highscore: " + sc.highscore.ToString();
	}
}
