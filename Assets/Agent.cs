using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	private bool alive;
	private NavMeshAgent agent;

	private GameObject[] players;
	private GameObject target;
	

	void Start ()
	{
		alive = true;
		agent = GetComponent<NavMeshAgent>();
		agent.speed = Random.Range(3.5f, 10f);

		players = GameObject.FindGameObjectsWithTag ("Player");
	}

	void Update ()
	{
		if (alive) {
			// target the closest player
			float shortestDistance = 1000f;
			foreach (GameObject player in players) {
				float playerDistance = Vector3.Distance(transform.position, player.transform.position);
				if (playerDistance < shortestDistance) {
					shortestDistance = playerDistance;
					target = player;
				}
			}

			agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
		}
	}

	public bool IsAlive() {
		return alive;
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "PlayerCollider") {
			DamageScript script = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageScript>();
			script.TakeDamage();
		}
	}

	public void SetAlive(bool a) {
		alive = a;
	}
}
