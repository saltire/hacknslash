using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Space) || Input.GetAxis("Attack1") > 0 || Input.GetAxis("Attack2") > 0) {
			GameObject.FindGameObjectWithTag("FadeObject").GetComponent<TransitionScript>().StartFade();
		}
	}
}
