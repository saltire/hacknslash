using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public int maxSpawn = 50;
	public GameObject agent;
	public bool active;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public GameObject player;
	public GameObject nextLevel;
	public List<GameObject> doors;

	private List<GameObject> agents;
	private int spawnCount;
	private float timeSinceLastSpawn;

	// Use this for initialization
	private void Start () {
		agents = new List<GameObject>();
		if (active) {
			SpawnFromPool();
		}
		timeSinceLastSpawn = 0f;
		spawnCount = 1;
	}

	private void GotoNextLevel() {
		if (nextLevel) {
			active = false;
			foreach(GameObject agent in agents) {
				Destroy(agent);
			}

			foreach(GameObject exit in doors) {
				Destroy(exit);
			}
		}
	}

	public void SetActive() {
		active = true;
	}

	private void SpawnFromPool() {
		GameObject newAgent = null;
		Agent script;
		foreach (GameObject a in agents) {
			script = a.GetComponent<Agent>();
			if (script && !script.IsAlive()) {
				newAgent = a;
			}
		}

		if (newAgent == null) {
			newAgent = (GameObject) GameObject.Instantiate(this.agent, new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minY, maxY)), Quaternion.identity);
		}
		else {
			Vector3 playerPos = player.transform.position;
			float x;
			bool invalid = true;
			do {
				x = Random.Range(minX, maxX);
				if (x != playerPos.x) {
					invalid = false;
				}
			} while(invalid);
			float y;
			invalid = true;
			do {
				y = Random.Range(minY, maxY);
				if (y != playerPos.x) {
					invalid = false;
				}
			} while(invalid);
			newAgent.transform.position = new Vector3(x, 0f, y);
		}

		agents.Add(newAgent);

		script = newAgent.GetComponent<Agent>();
		if (script) {
			script.SetAlive(true);
		}
	}

	// Update is called once per frame
	private void Update () {
		if (active) {
			timeSinceLastSpawn += Time.deltaTime;
			if (timeSinceLastSpawn > 0.5f && spawnCount < maxSpawn) {
				SpawnFromPool();
				timeSinceLastSpawn = 0f;
				spawnCount++;
			}

			if (spawnCount >= maxSpawn) {
				active = false;
			}
		}
		else {
			if (agents.Count == 0) {
				GotoNextLevel();
			}
		}
	}
}
