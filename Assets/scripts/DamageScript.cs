using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	public AudioClip hitSound;

	private int health;
	private float damageTimer;

	void Start () {
		ResetHP();
		damageTimer = 0f;
	}

	public int GetHealth() {
		return health;
	}

	public void ResetHP() {
		health = 10;
	}

	public void TakeDamage() {
		if (damageTimer > 0.5f) {
			damageTimer = 0f;
			health--;
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
			if (health < 0) {
				health = 0;
			}

			if (health == 0) {
				GetComponent<SimpleMove>().SetDead();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		damageTimer += Time.deltaTime;
	}
}
