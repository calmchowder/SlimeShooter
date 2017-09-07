using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
	}

    public void updateScore() {
        scoreText.text = "Score: " + score.ToString();
    }
         
	
}
