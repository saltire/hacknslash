using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentLevel;

	private bool fadeStarted;
	private int playerOneKC;
	private int playerTwoKC;
	// Use this for initialization
	void Start () {
		fadeStarted = false;
	}

	public void IncrementKillCountFor(int pn) {
		if (pn == 1) {
			playerOneKC++;
		}
		else if (pn == 2) {
			playerTwoKC++;
		}
	}

	void OnGUI() {
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		int i = 0;
		foreach(GameObject player in players) {
			if (player.name == "Player 1") {
				GUI.Label(new Rect(10, 10, 100, 20), "Player 1 HP: " + player.GetComponent<DamageScript>().GetHealth());
			}
			else if (player.name == "Player 2") {
				GUI.Label(new Rect(600, 10, 100, 20), "Player 2 HP: " + player.GetComponent<DamageScript>().GetHealth());
			}
			i++;
		}
		GUI.Label(new Rect(10, 33, 100, 20), "Kill Count: " + playerOneKC);
		GUI.Label(new Rect(600, 33, 100, 20), "Kill Count: " + playerTwoKC);
	}
	
	// Update is called once per frame
	void Update () {
		if (!fadeStarted) {
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			bool allDead = true;
			foreach(GameObject player in players) {
				SimpleMove script = player.GetComponent<SimpleMove>();
				if (!script.IsDead()) {
					allDead = false;
				}
			}
			
			if (allDead) {
				fadeStarted = true;
				GameObject.FindGameObjectWithTag("FadeObject").GetComponent<FadeToBlack>().StartFade();
			}
		}
	}
}
