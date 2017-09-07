using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public int attackDamage = 30;

    EnemyHealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy1")) {
            Debug.Log("Bullet Hit");
            enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.takeDamage(attackDamage);
            Destroy(gameObject);
        }
    }

}
