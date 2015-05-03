using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	private int health;
	private float damageTimer;
	// Use this for initialization
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
			health = Mathf.Clamp(health, 0, 6);

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
