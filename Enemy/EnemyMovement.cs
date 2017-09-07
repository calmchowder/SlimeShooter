using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;
    private Transform thePlayer;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
	}

    private void Update() {
        if (enemyHealth.isDead) {
            rb2d.velocity = Vector3.zero;
        }
    }

    // Move to player if it is alive. If not, then stop
    void FixedUpdate() {
        // If the player is alive, then continue to move.
        if (!playerHealth.isDead) {
       
            // Calculating angle between player and enemy
            Vector3 dir = thePlayer.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, speed * Time.deltaTime);

            /* Setting animations.
            * Walking just determines whether or not to play an idle animation or not. 
            * For Directions:
            *     0 = North
            *     1 = East
            *     2 = South
            *     3 = West
            */
            if (dir.x != 0 || dir.y != 0) {
                anim.SetBool("walking", true);
            }
            else {
                anim.SetBool("walking", false);
            }
            if (angle < 135 && angle > 45) {
                anim.SetInteger("Direction", 0);
            }
            else if (angle <= 45 && angle >= -45) {
                anim.SetInteger("Direction", 1);
            }
            else if (angle < -45 && angle > -135) {
                anim.SetInteger("Direction", 2);
            }
            else if ((angle <= 180 && angle >= 135) || (angle <= -135 && angle >= -180)) {
                anim.SetInteger("Direction", 3);
            }

        }
    }
   
}
