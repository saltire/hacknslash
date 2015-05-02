using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotateSpeed = 20f;
	
	private CharacterController player;

	void Start ()
	{
		player = GetComponent<CharacterController>();
	}

	void Update ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3 (h * moveSpeed, -100f, v * moveSpeed);
		player.Move (moveDirection * Time.deltaTime);
		
		if (h != 0 || v != 0) {
			player.transform.rotation = Quaternion.LookRotation (new Vector3 (h, 0, v));
			//player.transform.rotation = Quaternion.Lerp (player.transform.rotation, Quaternion.LookRotation (new Vector3 (h, 0, v)), Time.deltaTime * rotateSpeed);
		}
	}
}
