using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	private int health;
	private float damageTimer;
	// Use this for initialization
	void Start () {
		health = 5;
		damageTimer = 0f;
	}

	public void TakeDamage() {
		if (damageTimer > 0.5f) {
			damageTimer = 0f;
			health--;
			if (health == 0) {
				FadeToBlack script = GameObject.FindGameObjectWithTag("FadeObject").GetComponent<FadeToBlack>();
				script.StartFade();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		damageTimer += Time.deltaTime;
	}
}
