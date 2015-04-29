using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	private bool attacking;
	private float timeSinceAttack;
	private Quaternion originalRotationValue;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		Renderer r = gameObject.GetComponent<Renderer>();
		r.enabled = false;
		attacking = false;
		timeSinceAttack = 0f;
		originalRotationValue = transform.rotation;
		originalPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Renderer r = gameObject.GetComponent<Renderer>();
		if (!attacking && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))) {
			r.enabled = true;
			attacking = true;
		}

		if (attacking) {
			timeSinceAttack += Time.deltaTime;
			transform.RotateAround(transform.parent.position, Vector3.up, 5);
		}

		if (timeSinceAttack > 0.4f) {
			attacking = false;
			r.enabled = false;
			timeSinceAttack = 0f;
			transform.rotation = originalRotationValue;
			transform.localPosition = originalPos;
		}
	}
}
