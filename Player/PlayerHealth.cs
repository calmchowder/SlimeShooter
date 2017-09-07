using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 100;
    public float currentHealth;
    public bool isDead;
    public Image currentHPBar;
    public Text HPText;
    public Text HPPlusText;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    AudioSource audio;
    float tempHealth;
    Renderer rend;
    Animator anim;
    PlayerMovement playerMovement;

    void Awake () {
        audio = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = health;
        tempHealth = health;
	}

    private void Start() {
        // To initialize the HP bar as 100/100
        updateHPBar();
    }

    // Minus player HP
    public void takeDamage (int amount) {

        // Takes off the renderer for a flashing effect.
        rend.enabled = false;

        audio.clip = hurtSound;
        audio.Play();
        currentHealth -= amount;

        // Turns the renderer back on
        Invoke("playerFlash", 5f * Time.deltaTime);
        if (currentHealth <= 0 && !isDead) {
            Death();
        }

        updateHPBar();
    }

    // Heal the player if a health pack was picked up
    public void healHealth (int amount) {
        if(currentHealth + amount > 100) {
            currentHealth = 100;
        } else {
            currentHealth += amount;
        }
        // Show text and remove it after two seconds
        HPPlusText.text = "+20 Health";
        HPPlusText.GetComponent<Text>().enabled = true;
        updateHPBar();
        Invoke("removeHpPlus", 2f);
    }

    void removeHpPlus() {
        HPPlusText.GetComponent<Text>().enabled = false;
    }

    // Turns the renderer off and on to have a flashing effect on the player when hit
    void playerFlash() {
        rend.enabled = true;
    }

    // Prevent the player from moving and ends the game
    void Death() {
        isDead = true;
        anim.SetTrigger("Dead");
        audio.clip = deathSound;
        audio.Play();
        playerMovement.rb2d.velocity = new Vector2(0, 0);     
        playerMovement.enabled = false;
    }

    // Update the HP bar
    void updateHPBar() {
        float ratio = currentHealth / health;

        //To prevent the HP bar from going negative, or too high
        if(ratio < 0) {
            ratio = 0;
        } else if (ratio > 100) {
            ratio = 1;
        }

        currentHPBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        tempHealth = ratio;
        HPText.text = (ratio * 100).ToString();
    }

        
}
