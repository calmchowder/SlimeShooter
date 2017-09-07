using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float delayAttacks = 1f;
    public int attackDamage = 10;

    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    InRangeAttack inRangeAttack;
    float timer;

	void Awake () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        inRangeAttack = GetComponentInChildren<InRangeAttack>();
	}


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        // Checks if we can attack in time, if we are in range, and if the enemy is still alive to attack us.
        if(timer >= delayAttacks && inRangeAttack.inAttackRange && enemyHealth.currentHealth > 0) {
            Attack();
        }

	}

    void Attack() {
        // Resets the attack timer
        timer = 0f;

        if(playerHealth.currentHealth > 0) {
            playerHealth.takeDamage(attackDamage);
        }
    }
}
