using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public GameObject target;

	private NavMeshAgent agent;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate ()
	{
		// agent will move to mouse click
		// if (Input.GetMouseButtonDown(0))
		// {
		// 	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//
		// 	RaycastHit hit;
		// 	if (Physics.Raycast(ray, out hit))
		// 	{
		// 		if (hit.collider.tag == "Ground")
		// 		{
		// 			agent.SetDestination(hit.point);
		// 		}
		// 	}
		// }

		// agent will move to target gameobject
		agent.SetDestination(new Vector3(target.transform.position.x, 0f, target.transform.position.z));
	}
}
