using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public int PlayerNumber;
	public float sweepAngle = 60f;
	public float sweepTime = 0.5f;

	private float cacheSweepAngle;
	private float cacheSweepTime;
	
	private bool attacking;
	private float angleMoved;

	private Vector3 startPosition;
	private Quaternion startRotation;

	private Renderer r;

	// Use this for initialization
	void Start () {
		r = gameObject.GetComponentsInChildren<Renderer>()[0];
		r.enabled = false;
		attacking = false;

		startPosition = transform.position - transform.parent.position;
		startRotation = Quaternion.FromToRotation (transform.parent.position, transform.position);
		cacheSweepAngle = sweepAngle;
		cacheSweepTime = sweepTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking && Input.GetAxis("Attack" + PlayerNumber) > 0) {
			r.enabled = true;
			attacking = true;

			transform.position = startPosition + transform.parent.position;
			transform.rotation = transform.parent.rotation * startRotation;
			transform.RotateAround (transform.parent.position, Vector3.up, sweepAngle * -0.5f);
			angleMoved = 0;

			GameObject bouncer = GameObject.FindGameObjectWithTag("Bouncer");
			
			if (bouncer) {
				Vector3 vec = bouncer.transform.localPosition;
				if (vec.x > -1.5f && vec.x < 1.5f) {
					sweepAngle = 360f;
					sweepTime = 0.6f;
				}
			}
		}

		if (attacking) {
			float angle = sweepAngle * Time.deltaTime / sweepTime;
			transform.RotateAround(transform.parent.position, Vector3.up, angle);
			angleMoved += angle;

			if (angleMoved > sweepAngle) {
				attacking = false;
				r.enabled = false;
				sweepAngle = cacheSweepAngle;
				sweepTime = cacheSweepTime;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (attacking && other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}
}
