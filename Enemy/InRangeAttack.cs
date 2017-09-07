using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeAttack : MonoBehaviour {

    public bool inAttackRange;

    // Checks if the enemy is in range to attack
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Collided");
            inAttackRange = true;
        }
    }

    // If the enemy was in range, but has now left the range, it cannot attack anymore
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            inAttackRange = false;
        }
    }

}
