using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float attackTimer;
    public float shootTimer;
    public Rigidbody2D rb2d;
    public GameObject bulletPreFab;
    public Text ammoNumber;
    public Text bulletPlusText;
    public float numKilled;

    private float ammo;
    private int direction;
    private GameObject bullet;
    private float timer;
    private float yvelocity;
    private float xvelocity;
    private Vector2 finalvelocity;
    PlayerHealth playerHealth;
    PlayerAttack0 playerAttack0;
    PlayerAttack1 playerAttack1;
    PlayerAttack2 playerAttack2;
    PlayerAttack3 playerAttack3;
    Animator anim;

	// Use this for initialization
	void Start () {
        ammo = 10;
        direction = 4;
        ammoNumber.text = ammo.ToString();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack0 = GetComponentInChildren<PlayerAttack0>();
        playerAttack1 = GetComponentInChildren<PlayerAttack1>();
        playerAttack2 = GetComponentInChildren<PlayerAttack2>();
        playerAttack3 = GetComponentInChildren<PlayerAttack3>();
	}

    // Used to add ammo
    public void addAmmo(int amount) {
        ammo += amount;
        ammoNumber.text = ammo.ToString();
        bulletPlusText.text = "+5 Bullets";
        bulletPlusText.GetComponent<Text>().enabled = true;
        Invoke("bulletPlusEnd", 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        // Modify the velocity each frame depending on input 
        rb2d.velocity = finalvelocity;
        // If player is dead, stop movement
        if(playerHealth.isDead) {
            rb2d.velocity = Vector3.zero;
        }

        timer += Time.deltaTime;
        // If the user presses N for the melee sword attack, execute the attack function
        if (Input.GetKeyDown(KeyCode.N) && timer >= attackTimer) {
            // Reset the timer
            timer = 0;
            // Check the direction to determine which melee attack is played. The attack numbers are the same as the directions for movement.
            if(anim.GetInteger("Direction") == 0) {
                playerAttack0.enabled = true;
            } else if (anim.GetInteger("Direction") == 1) {
                playerAttack1.enabled = true;
            } else if (anim.GetInteger("Direction") == 2) {
                playerAttack2.enabled = true;
            } else if (anim.GetInteger("Direction") == 3) {
                playerAttack3.enabled = true;
            }
        }
        // Resets the sword
        if (playerAttack0.updateOrNot) {
            playerAttack0.enabled = false;
            playerAttack0.updateOrNot = false;
        } else if(playerAttack1.updateOrNot) {
            playerAttack1.enabled = false;
            playerAttack1.updateOrNot = false;
        } else if(playerAttack2.updateOrNot) {
            playerAttack2.enabled = false;
            playerAttack2.updateOrNot = false;
        } else if(playerAttack3.updateOrNot) {
            playerAttack3.enabled = false;
            playerAttack3.updateOrNot = false;
        }

        // If the user gets 4 kill awards, they are awarded with one bullet
        if (numKilled >= 4) {
            ammo += 1;
            ammoNumber.text = ammo.ToString();
            numKilled -= 4;
            bulletPlusText.text = "+1 Bullet";
            bulletPlusText.GetComponent<Text>().enabled = true;
            Invoke("bulletPlusEnd", 1.5f);
        }

        //If the user presses M for the ranged bullet attack, Instantiate the bullet in one of eight directions
        if (Input.GetKeyDown(KeyCode.M) && timer >= shootTimer && ammo > 0) {

            //Reset the timer
            timer = 0;

            // Minus one ammo
            ammo -= 1;
            ammoNumber.text = ammo.ToString();
            if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) || direction == 1) {
                shootBullet(25, 25, 500f, 500f);
            }
            else if (((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) || direction == 3) {
                shootBullet(25, -25, 500f, -500f);
            }
            else if (((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) || direction == 5) {
                shootBullet(-25, -25, -500f, -500f);
            }
            else if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) || direction == 7) {
                shootBullet(-25, 25, -500f, 500f);
            }
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) || direction == 0) {
                shootBullet(0, 30, 0f, 707f);
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) || direction == 2) {
                shootBullet(30, 0, 707f, 0f);
            }     
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) || direction == 4) {
                shootBullet(0, -30, 0f, -707f);
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) || direction == 6) {
                shootBullet(-30, 0, -707f, 0f);
            }
        }
	}

    // Movement-related code
    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        xvelocity = h * speed;
        yvelocity = v * speed;

        if(xvelocity > maxSpeed || xvelocity < -maxSpeed) {
            xvelocity = h * maxSpeed;
        }
        if(yvelocity > maxSpeed || yvelocity < -maxSpeed) {
            yvelocity = v * maxSpeed;
        }

        // If going in a diagonal direction, limit the speed by pythag value 
        if(((h == 1) || (h == -1)) && ((v == 1) || (v == -1))) {
            xvelocity /= Mathf.Sqrt(2);
            yvelocity /= Mathf.Sqrt(2);
        }
        finalvelocity = new Vector2(xvelocity, yvelocity);

        /* Setting animations.
         * Walking just determines whether or not to play an idle animation or not. 
         * For Directions:
         *     0 = North
         *     1 = East
         *     2 = South
         *     3 = West
         */
        
        if (xvelocity != 0 || yvelocity != 0) {
            anim.SetBool("walking", true);
        } else {
            anim.SetBool("walking", false);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            anim.SetInteger("Direction", 0);
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            anim.SetInteger("Direction", 1);
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            anim.SetInteger("Direction", 2);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetInteger("Direction", 3);
        }

        // Storing the last direction (mainly for shooting when still)
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
            direction = 1;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
            direction = 3;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            direction = 5;
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            direction = 7;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            direction = 0;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            direction = 2;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            direction = 4;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            direction = 6;
        }

        // Clamping the position based on the map to prevent the player from walking off 
        rb2d.position = new Vector3(Mathf.Clamp(rb2d.position.x, -775, 775), Mathf.Clamp(rb2d.position.y, -810, 750), 0);

    }

    private void shootBullet(int xpos, int ypos, float xforce, float yforce) {
        bullet = Instantiate(bulletPreFab, new Vector3(transform.position.x + xpos, transform.position.y + ypos, transform.position.z), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xforce, yforce), ForceMode2D.Impulse);
    }

    void bulletPlusEnd() {
        bulletPlusText.GetComponent<Text>().enabled = false;
    }
}
