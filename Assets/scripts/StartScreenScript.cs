using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Submit") > 0) {
			GameObject.FindGameObjectWithTag("FadeObject").GetComponent<TransitionScript>().StartFade();
		}

		if (Input.GetAxis("Escape") > 0) {
			Application.Quit();
		}
	}
}
