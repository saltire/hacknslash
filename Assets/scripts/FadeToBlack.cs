using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	private Color blackColor;
	private bool fading;
	private float fadeTime;

	public void StartFade() {
		this.transform.position = new Vector3(0, this.transform.position.y, 94);
		fading = true;
		fadeTime = 0f;
	}

	// Use this for initialization
	void Start () {
		fading = false;
		blackColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			if (fadeTime < 2) {
				fadeTime += Time.deltaTime;
				Renderer renderer = GetComponent<Renderer>();
				blackColor.a = Mathf.Clamp(fadeTime / 2f, 0f, 2f);
				renderer.material.color = blackColor;
			}
			else {
				if (Input.GetKey(KeyCode.Space)) {
					Application.LoadLevel(0);
				}
			}
		}
	}
}
