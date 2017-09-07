using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    PlayerHealth playerHealth;

    private void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        // If the player is not already at max health and is still alive
        if(collision.gameObject.CompareTag("Player")) {
            if (playerHealth.currentHealth < 100 && !playerHealth.isDead) {
                playerHealth.healHealth(20);
                Destroy(gameObject);
            }
        }
    }

}
