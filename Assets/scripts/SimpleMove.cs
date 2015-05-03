using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public int PlayerNumber;
	private bool dead;
	public float moveSpeed = 10f;
	public float rotateSpeed = 20f;
	
	private CharacterController player;

	// this is used by the weapon and the player sprite, but not by the player object itself
	private Quaternion lookRotation;

	void Start ()
	{
		dead = false;
		player = GetComponent<CharacterController>();

		lookRotation = player.transform.rotation;
	}


	public bool IsDead() {
		return dead;
	}

	public void SetAlive() {
		dead = false;
	}

	public void SetDead() {
		dead = true;
	}

	public Quaternion getRotation() {
		return lookRotation;
	}

	void Update ()
	{
		if (!dead) {
			float h = Input.GetAxis("Horizontal" + PlayerNumber);
			float v = Input.GetAxis("Vertical" + PlayerNumber);

			Vector3 moveDirection = new Vector3 (h * moveSpeed, -100f, v * moveSpeed);
			player.Move (moveDirection * Time.deltaTime);
			
			if (h != 0 || v != 0) {
				lookRotation = Quaternion.LookRotation (new Vector3 (h, 0, v));
			}
		}
	}
}
