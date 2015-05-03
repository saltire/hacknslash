using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public int PlayerNumber;
	private bool dead;
	public float moveSpeed = 10f;
	public float rotateSpeed = 20f;
	
	private CharacterController player;

	void Start ()
	{
		dead = false;
		player = GetComponent<CharacterController>();
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

	void Update ()
	{
		if (!dead) {
			float h = Input.GetAxis("Horizontal" + PlayerNumber);
			float v = Input.GetAxis("Vertical" + PlayerNumber);

			Vector3 moveDirection = new Vector3 (h * moveSpeed, -100f, v * moveSpeed);
			player.Move (moveDirection * Time.deltaTime);
			
			if (h != 0 || v != 0) {
				player.transform.rotation = Quaternion.LookRotation (new Vector3 (h, 0, v));
				//player.transform.rotation = Quaternion.Lerp (player.transform.rotation, Quaternion.LookRotation (new Vector3 (h, 0, v)), Time.deltaTime * rotateSpeed);
			}
		}
	}
}
