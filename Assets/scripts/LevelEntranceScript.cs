using UnityEngine;
using System.Collections;

public class LevelEntranceScript : MonoBehaviour {
	public float cameraMoveTime = 1f;

	private GameObject mainCamera;
	public GameObject targetLevel;
	private Transform cameraPoint;
	private int playerCount;

	private bool waiting;
	private Vector3 cameraOriginalPosition;
	private float cameraMoveElapsed;
	
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		cameraPoint = transform.parent.Find ("Camera");

		waiting = true;
		playerCount = 0;

		cameraMoveElapsed = 0;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			playerCount += 1;

			int playerTotal = 0;
			foreach (GameObject player in GameObject.FindGameObjectsWithTag ("Player")) {
				if (!player.GetComponent<SimpleMove>().IsDead()) {
					playerTotal += 1;
				}
			}

			if (waiting && playerCount == playerTotal) {
				// tell camera to move
				cameraOriginalPosition = mainCamera.transform.position;
				waiting = false;

				// enable forward movement and disable backward movement
				transform.Find ("Before Collider").gameObject.SetActive (false);
				transform.Find ("After Collider").gameObject.SetActive (true);

				// activate spawn points
				foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint")) {
					spawnPoint.GetComponent<EnemySpawnPoint>().isActive = (spawnPoint.transform.parent == transform.parent);
				}

				foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
					Destroy(enemy);
				}

				GameObject.FindGameObjectWithTag("Levels").GetComponent<LevelManager>().currentLevel = targetLevel;

				SwitchMusic music = gameObject.GetComponent<SwitchMusic>();
				if (music) {
					music.switchMusic();
				}
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			playerCount -= 1;
		}
	}

	void Update () {
		// move camera
		if (!waiting && cameraMoveElapsed < cameraMoveTime) {
			mainCamera.transform.position = Vector3.Lerp (cameraOriginalPosition, cameraPoint.position, cameraMoveElapsed / cameraMoveTime);
			cameraMoveElapsed += Time.deltaTime;
		}
	}
}
