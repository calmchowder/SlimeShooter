using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour {

    public GameObject ammoSpawn;
    public float spawnDelay;
    public Transform[] spawnPoints;

    private int lastIndex;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("spawnAmmo", 5f, spawnDelay);
	}

    void spawnAmmo() {
        if(playerHealth.currentHealth > 0) {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            if (spawnIndex == lastIndex) {
                spawnIndex++;
                // If last position was 3, and it sets it to 4, change it to 0 since 4 does not exist.
                if (spawnIndex == spawnPoints.Length) {
                    spawnIndex = 0;
                }
            }
            lastIndex = spawnIndex;
            Instantiate(ammoSpawn, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
	
	
}
