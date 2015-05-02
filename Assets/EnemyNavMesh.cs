using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	private bool alive;
	private NavMeshAgent agent;

	private GameObject[] players;
	private GameObject target;
	private int hp;
	private float lastTimeDamaged;
	

	void Start ()
	{
		alive = true;
		agent = GetComponent<NavMeshAgent>();
		agent.speed = Random.Range(3.5f, 10f);
		hp = Random.Range(1, 3);
		players = GameObject.FindGameObjectsWithTag ("Player");
		lastTimeDamaged = Time.time;
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

	public void TakeDamage() {
		if (Time.time - lastTimeDamaged > 0.25f) {
			lastTimeDamaged = Time.time;
			hp--;
			if (hp == 0) {
				alive = false;
				Destroy(gameObject);
			}
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
