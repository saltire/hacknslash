using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

	private EnemySpawnPoint[] spawnPoints;
	private GameObject victory;

	void Start () {
		spawnPoints = gameObject.GetComponentsInChildren<EnemySpawnPoint> ();
		victory = gameObject.transform.Find("Victory").gameObject;
	}
	
	void Update () {
		if (!victory.activeSelf) {
			foreach (EnemySpawnPoint spawnPoint in spawnPoints) {
				if (!spawnPoint.ReachedLimit ()) {
					return;
				}
			}

			if (GameObject.FindObjectsOfType<EnemyNavMesh> ().Length == 0) {
				victory.SetActive (true);
			}
		}
	}
}
