using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	private Color color;
	private bool fading;
	private float fadeTime;

	public void StartFade() {
		fading = true;
		fadeTime = 0f;
		GetComponent<SpriteRenderer> ().enabled = true;
	}

	// Use this for initialization
	void Start () {
		color = Color.black;
		color.a = 0f;
		fading = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			if (fadeTime < 2) {
				fadeTime += Time.deltaTime;
				SpriteRenderer renderer = GetComponent<SpriteRenderer>();
				color.a = Mathf.Clamp(fadeTime / 2f, 0f, 2f);
				renderer.color = color;
			}
			else {
				if (Input.GetAxis("Submit") > 0) {
					Application.LoadLevel(0);
				}
			}
		}
	}
}
