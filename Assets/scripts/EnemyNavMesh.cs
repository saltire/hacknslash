using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	private bool alive;
	private NavMeshAgent agent;

	private GameObject[] players;
	private GameObject target;
	private int hp;
	private float lastTimeDamaged;
	private Vector3 lastPosition;
	private Animator anim;
	private Transform sprite;

	void Start ()
	{
		alive = true;
		agent = GetComponent<NavMeshAgent>();
		agent.speed = Random.Range(3.5f, 10f);
		hp = 1;
		players = GameObject.FindGameObjectsWithTag ("Player");
		lastTimeDamaged = Time.time;

		lastPosition = transform.position;
		anim = transform.GetComponentInChildren<Animator>();
		sprite = transform.Find ("Sprite");
	}

	void Update ()
	{
		// rotate sprite to compensate for the agent's rotation and keep it the right way up
		sprite.rotation = Quaternion.Euler (90, transform.rotation.y, 0);

		// set animator variables
		anim.SetFloat("direction", transform.rotation.eulerAngles.y);
		anim.SetFloat("speed", Vector3.Distance(transform.position, lastPosition) / Time.deltaTime);

		if (alive) {
			// target the closest player
			float shortestDistance = 1000f;
			target = null;
			foreach (GameObject player in players) {
				if (!player.GetComponent<SimpleMove>().IsDead()) {

					float playerDistance = Vector3.Distance(transform.position, player.transform.position);
					if (playerDistance < shortestDistance) {
						shortestDistance = playerDistance;
						target = player;
					}
				}
			}

			if (target) {
				agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
			}

			lastPosition = transform.position;
		}
	}

	public void TakeDamage(int PlayerNumber) {
		if (Time.time - lastTimeDamaged > 0.25f) {
			lastTimeDamaged = Time.time;
			hp--;
			if (hp == 0) {
				alive = false;
				GameObject.FindGameObjectWithTag("Levels").GetComponent<LevelManager>().IncrementKillCountFor(PlayerNumber);
				Destroy(gameObject);
			}
		}
	}

	public bool IsAlive() {
		return alive;
	}

	void OnTriggerStay(Collider collision) {
		if (collision.gameObject.tag == "DamageCollider") {
			DamageScript script = collision.gameObject.transform.parent.gameObject.GetComponent<DamageScript>();
			script.TakeDamage();
		}
	}

	public void SetAlive(bool a) {
		alive = a;
	}
}
