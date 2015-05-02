using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject level;
	private bool fadeStarted;
	// Use this for initialization
	void Start () {
		fadeStarted = false;
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
