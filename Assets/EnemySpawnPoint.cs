using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject enemy;
	public float spawnInterval = 1f;
	public bool isActive = false;

	private float timeSinceSpawn;

	void Start () {
		timeSinceSpawn = 0;
	}
	
	void Update () {
		if (isActive) {
			timeSinceSpawn += Time.deltaTime;
			if (timeSinceSpawn > spawnInterval) {
				Instantiate (enemy, transform.position, transform.rotation);
				timeSinceSpawn = 0;
			}
		}
	}
}
