using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject enemy;
	public float spawnInterval = 1f;
	public bool isActive = false;
	private float spawnCount = 0;
	public float spawnLimit = 50;

	private float timeSinceSpawn;

	void Start () {
		timeSinceSpawn = 0;
	}

	public bool ReachedLimit() {
		return spawnCount >= spawnLimit;
	}
	
	void Update () {
		if (isActive) {
			timeSinceSpawn += Time.deltaTime;
			if (timeSinceSpawn > spawnInterval) {
				Instantiate (enemy, transform.position, transform.rotation);
				timeSinceSpawn = 0;
				spawnCount++;
			}
			if (ReachedLimit()) {
				isActive = false;
			}
		}
	}
}
