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
		// this renderer is only for the stand-in asset
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
		SimpleMove sm = transform.parent.gameObject.GetComponent<SimpleMove>();
		if (!sm.IsDead() && !attacking && Input.GetAxis("Attack" + PlayerNumber) > 0) {
			r.enabled = true;
			attacking = true;

			// place weapon collider at start of swing
			transform.position = startPosition + transform.parent.position;
			transform.rotation = transform.parent.gameObject.GetComponent<SimpleMove>().getRotation() * startRotation;
			transform.RotateAround (transform.parent.position, Vector3.up, sweepAngle * -0.5f);
			angleMoved = 0;

			// trigger animation
			transform.parent.GetComponentInChildren<Animator>().SetBool("attacking", true);

			// use a power attack if bouncer is in the right position
			GameObject bouncer = GameObject.FindGameObjectWithTag("Bouncer");
			if (bouncer) {
				Vector3 vec = bouncer.transform.localPosition;
				if (vec.x > -1.5f && vec.x < 1.5f) {
					sweepAngle = 360f;
					sweepTime = 0.3f;
					transform.parent.GetComponentInChildren<Animator>().SetBool("spinning", true);
				}
			}
		}

		if (attacking) {
			float angle = sweepAngle * Time.deltaTime / sweepTime;
			transform.RotateAround(transform.parent.position, Vector3.up, angle);
			angleMoved += angle;

			if (angleMoved > sweepAngle) {
				// end attack
				attacking = false;
				transform.parent.GetComponentInChildren<Animator>().SetBool("attacking", false);
				transform.parent.GetComponentInChildren<Animator>().SetBool("spinning", false);

				r.enabled = false;

				sweepAngle = cacheSweepAngle;
				sweepTime = cacheSweepTime;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (attacking && other.gameObject.tag == "Enemy") {
			EnemyNavMesh script = other.gameObject.GetComponent<EnemyNavMesh>();
			script.TakeDamage(PlayerNumber);
		}
	}
}
