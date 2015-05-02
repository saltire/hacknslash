using UnityEngine;
using System.Collections;

public class LevelEntranceScript : MonoBehaviour {
	private GameObject mainCamera;
	private Transform cameraPoint;
	private int playerCount;
	private int playerTotal;
	private bool waiting;
	
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		cameraPoint = transform.parent.Find ("Camera");

		waiting = true;
		playerCount = 0;
		playerTotal = GameObject.FindGameObjectsWithTag ("Player").Length;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			playerCount += 1;

			if (waiting && playerCount == playerTotal) {
				// move camera
				mainCamera.transform.position = cameraPoint.position;

				// enable forward movement and disable backward movement
				transform.Find ("Before Collider").gameObject.SetActive (false);
				transform.Find ("After Collider").gameObject.SetActive (true);

				// activate spawn points
				foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint")) {
					spawnPoint.GetComponent<EnemySpawnPoint>().isActive = (spawnPoint.transform.parent == transform.parent);
				}
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			playerCount -= 1;
		}
	}
}
