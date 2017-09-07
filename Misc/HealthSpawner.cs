using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour {

    public GameObject healthPickup;
    public float spawnDelay;
    public Transform[] spawnPoints;

    private int lastIndex;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        lastIndex = -1;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("SpawnHealthPack", 5f, spawnDelay);
	}
	
	void SpawnHealthPack() {
        if(playerHealth.currentHealth > 0f) {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            // If it chooses the same position as last time
            if(spawnIndex == lastIndex) {
                spawnIndex++;
                // If last position was 3, and it sets it to 4, change it to 0 since 4 does not exist.
                if(spawnIndex == spawnPoints.Length) {
                    spawnIndex = 0;
                }
            }
            lastIndex = spawnIndex;
            Instantiate(healthPickup, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

}
