using UnityEngine;
using System.Collections;

public class SwitchMusic : MonoBehaviour {

	public AudioSource musicClip;

	void Start () {
	
	}
	
	public void switchMusic() {
		foreach (AudioSource clip in GameObject.FindObjectsOfType<AudioSource>()) {
			clip.Stop();
		}

		musicClip.Play();
	}
}
