using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public GameObject target;

	private bool alive;
	private NavMeshAgent agent;

	public bool IsAlive() {
		return alive;
	}

	void Start ()
	{
		alive = true;
		agent = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate ()
	{
		if (alive) {
			// agent will move to target gameobject
			agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
		}
	}

	public void SetAlive() {
		alive = true;
	}
}
