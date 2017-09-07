using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 30;
    public int currentHealth;
    public bool isDead;
    public bool swordHit;

    AudioSource audioSource;
    GameObject thePlayer;
    PlayerMovement playerMovement;
    EnemyMovement enemyMovement;
    ScoreManager scoreManager;
    PlayerAttack0 playerAttack0;
    PlayerAttack1 playerAttack1;
    PlayerAttack2 playerAttack2;
    PlayerAttack3 playerAttack3;
    Rigidbody2D rb2d;
    CapsuleCollider2D collide;
    CircleCollider2D trigger;
    Renderer rend;
    Animator anim;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerAttack0 = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAttack0>();
        playerAttack1 = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAttack1>();
        playerAttack2 = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAttack2>();
        playerAttack3 = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAttack3>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        rb2d = GetComponent<Rigidbody2D>();
        collide = GetComponent<CapsuleCollider2D>();
        trigger = GetComponentInChildren<CircleCollider2D>();
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        currentHealth = health;
    }
	
	public void takeDamage(int amount) {

        // Turns the rend off for a flashing effect
        rend.enabled = false;

        audioSource.Play();
        currentHealth -= amount;

        // Apply knockback if it was a sword hit. 
        if(swordHit) {
            
            // Knock back the enemy a bit
            Vector2 difference = transform.position - thePlayer.transform.position;
            // If enemy is too close, then double the knockback (because it is based on the difference Vector)
            if (Mathf.Abs(difference.x) + Mathf.Abs(difference.y) < 50) {
                Debug.Log("Too Close");
                if(gameObject.CompareTag("Enemy")) {
                    difference *= 4f;
                } else if (gameObject.CompareTag("Enemy1")) {
                    difference *= 1.5f;
                }
                
            }
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y) + difference;
            transform.position = newPos;
           
        }
            

        // Turns the rend back on
        Invoke("enemyFlash", 5f * Time.deltaTime);

        // If health is less than zero, play death. If already dead, don't play death again (if took another instance of damage)
        if (currentHealth <= 0 && !isDead) {
            Death();
            Invoke("removeEnemy", 1f);
        }
    }

    // Turns the renderer off and on to have a flashing effect on the player when hit
    void enemyFlash() {
        rend.enabled = true;
    }

    // Plays the death animation and turns off all colliders
    void Death() {
        isDead = true;
        trigger.enabled = false;
        collide.enabled = false;
        enemyMovement.enabled = false;
        anim.SetTrigger("Death");
        Debug.Log(gameObject.name);
        if (gameObject.CompareTag("Enemy")) {
            playerMovement.numKilled += 1;
            scoreManager.score += 10;
        }
        else if (gameObject.CompareTag("Enemy1")) {
            playerMovement.numKilled += 2;
            scoreManager.score += 25;
        }
        scoreManager.updateScore();
    }

    void removeEnemy() { 
        Destroy(gameObject);
    }
}

