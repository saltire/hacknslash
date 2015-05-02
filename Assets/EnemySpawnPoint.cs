using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject enemy;
	public float spawnInterval = 1f;

	private List<Transform> spawnPoints;
	private float timeSinceSpawn;

	void Start () {
		spawnPoints = new List<Transform> ();
		foreach (Transform child in gameObject.GetComponentsInChildren<Transform> ()) {
			if (child.name == "Spawn Point") {
				Debug.Log (child);
				spawnPoints.Add (child);
			}
		}

		timeSinceSpawn = 0;
	}
	
	void Update () {
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn > spawnInterval) {
			foreach (Transform spawnPoint in spawnPoints) {
				Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
				timeSinceSpawn = 0;
			}
		}
	}
}
