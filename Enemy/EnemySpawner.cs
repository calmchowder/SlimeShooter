using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnDelay1;
    public float spawnDelay2;
    public Transform[] spawnPoints;

    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("SpawnEnemy1", 0f, spawnDelay1);
        InvokeRepeating("SpawnEnemy2", 0f, spawnDelay2);

        InvokeRepeating("SpawnEnemy1", 31f, spawnDelay1);
        InvokeRepeating("SpawnEnemy2", 61f, spawnDelay2);

        InvokeRepeating("SpawnEnemy1", 91f, spawnDelay1);
        InvokeRepeating("SpawnEnemy2", 121f, spawnDelay2);

        InvokeRepeating("SpawnEnemy1", 151f, spawnDelay1);
        InvokeRepeating("SpawnEnemy2", 181f, spawnDelay2);

        InvokeRepeating("SpawnEnemy1", 211f, spawnDelay1);
        InvokeRepeating("SpawnEnemy2", 241f, spawnDelay2);
        //At this point, the game should basically be impossible 
	}
	
	void SpawnEnemy1() {
        // If the player is alive, continue to spawn enemies
        if(playerHealth.currentHealth > 0f) {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy1, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    void SpawnEnemy2() {
        if(playerHealth.currentHealth > 0f) {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy2, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }


}
