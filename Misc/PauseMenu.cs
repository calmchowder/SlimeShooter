using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public Text pauseHighScoreText;

    DeathMenu deathMenu;

    // Canvas is disabled by default
    Canvas canvas;
    PlayerHealth playerHealth;
    bool gamePaused;

    // Resets the volume of the game when starting it
    void Awake() {
        unpaused.TransitionTo(0f);
    }

    // Use this for initialization
    void Start () {
        deathMenu = GameObject.FindGameObjectWithTag("Death").GetComponent<DeathMenu>();
        canvas = GetComponent<Canvas>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        deathMenu.highscore = PlayerPrefs.GetFloat("highscore", deathMenu.highscore);
        pauseHighScoreText.text = "High Score: " + deathMenu.highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        // If the player is not dead, you are able to pause
        if(!playerHealth.isDead) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (!gamePaused) {
                    canvas.enabled = true;
                    Pause();
                }
                else {
                    canvas.enabled = false;
                    unPause();
                }
            }
        }
	}

    // Pauses the game (brings up the canvas)
    void Pause() {
        Time.timeScale = 0;
        gamePaused = true;
        Lowpass();
    }

    // Unpauses the game (takes down the canvas)
    public void unPause() {
        canvas.enabled = false;
        Time.timeScale = 1;
        gamePaused = false;
        Lowpass();
    }

    // Turns down the audio during the pause menu, and brings it back up when done
    void Lowpass() {
        if(gamePaused) {
            paused.TransitionTo(.01f);
        } else {
            unpaused.TransitionTo(.01f);
        }
    }

    // Button to go back to menus
    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    // Button to quit the game
    public void Quit() {
        Application.Quit();
    }

    // Button to play again
    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
