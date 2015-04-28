using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	private CharacterController player;
	private float speed = 10f;

	void Start ()
	{
		player = GetComponent<CharacterController>();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(h * speed, -100f, v * speed);
		player.Move(moveDirection * Time.deltaTime);
	}
}
