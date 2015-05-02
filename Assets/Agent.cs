using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public GameObject target;

	private bool alive;
	private NavMeshAgent agent;

	void Start ()
	{
		alive = true;
		agent = GetComponent<NavMeshAgent>();
		agent.speed = Random.Range(3.5f, 10f);
	}

	void FixedUpdate ()
	{
		if (alive) {
			// agent will move to target gameobject
			agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
		}
	}

	public bool IsAlive() {
		return alive;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			DamageScript script = collision.gameObject.GetComponent<DamageScript>();
			script.TakeDamage();
		}
	}

	public void SetAlive(bool a) {
		alive = a;
	}
}
