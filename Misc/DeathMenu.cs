using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public Text highScoreText;
    public AudioMixerSnapshot paused;
    public float highscore;

    Canvas canvas;
    ScoreManager scoreManager;
    PlayerHealth playerHealth;


    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        highScoreText.text = "Highscore: " + highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.isDead) {
            if(scoreManager.score > highscore) {
                highscore = scoreManager.score;
                highScoreText.text = "High Score: " + highscore.ToString();
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            canvas.enabled = true;
            paused.TransitionTo(.01f);
        }
	}
}
