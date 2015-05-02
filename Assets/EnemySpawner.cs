﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public int maxSpawn = 50;
	public GameObject agent;
	public GameObject player;

	private List<GameObject> agents;
	private int spawnCount;
	private float timeSinceLastSpawn;

	// Use this for initialization
	private void Start () {
		agents = new List<GameObject>();
		agents.Add(agent);
		timeSinceLastSpawn = 0f;
		spawnCount = 1;
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
			newAgent = (GameObject) GameObject.Instantiate(this.agent, new Vector3(Random.Range(-4, 4), 0f, Random.Range(-4, 4)), Quaternion.identity);
		}
		else {
			Vector3 playerPos = player.transform.position;
			float x;
			bool invalid = true;
			do {
				x = Random.Range(-4, 4);
				if (x != playerPos.x) {
					invalid = false;
				}
			} while(invalid);
			float y;
			invalid = true;
			do {
				y = Random.Range(-4, 4);
				if (y != playerPos.x) {
					invalid = false;
				}
			} while(invalid);
			newAgent.transform.position.Set(x, 0f, y);
		}

		script = newAgent.GetComponent<Agent>();
		if (script) {
			script.SetAlive();
		}
	}

	// Update is called once per frame
	private void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn > 0.5f && spawnCount < maxSpawn) {
			SpawnFromPool();
			timeSinceLastSpawn = 0f;
			spawnCount++;
		}
	}
}
