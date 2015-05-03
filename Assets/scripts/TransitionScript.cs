using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {
	
	private Color color;
	private bool fading;
	public float fadeTime;

	public int targetLevel;
	
	public void StartFade() {
		fading = true;
		fadeTime = 0f;
	}
	
	// Use this for initialization
	void Start () {
		fading = false;
		color = Color.black;
		color.a = 0f;
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.color = color;
		fadeTime = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			if (fadeTime < 2) {
				fadeTime += Time.deltaTime;
				Renderer renderer = GetComponent<Renderer>();
				color.a = Mathf.Clamp(fadeTime / 2f, 0f, 2f);
				renderer.material.color = color;
			}
			else {
				Application.LoadLevel(targetLevel);
			}
		}
	}
}
