using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour {

    public float turnSpeed;
    public bool updateOrNot;
    public int attackDamage = 10;

    private Vector3 originalRotation;
    Renderer render;
    CapsuleCollider2D collide;
    EnemyHealth enemyHealth;

    public void Start() {
        render = GetComponent<Renderer>();
        collide = GetComponent<CapsuleCollider2D>();
        originalRotation = transform.eulerAngles;
    }

    public void Update() {
        if (transform.localRotation.z <= 0.9 || updateOrNot) {
            rotateBack();
        }
        else {
            Attack();
        }
    }

    public void Attack() {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 110), turnSpeed * Time.deltaTime);
        render.enabled = true;
        collide.enabled = true;
    }

    void rotateBack() {
        transform.eulerAngles = originalRotation;
        updateOrNot = true;
        render.enabled = false;
        collide.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy1")) {
            enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth.currentHealth > 0) {
                enemyHealth.swordHit = true;
                enemyHealth.takeDamage(attackDamage);
                enemyHealth.swordHit = false;
            }
        }
    }

}
