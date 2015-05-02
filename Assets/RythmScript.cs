using UnityEngine;
using System.Collections;

public class RythmScript : MonoBehaviour {
	
	public float speed;
	
	private enum Direction {
		LEFT,RIGHT
	};
	
	private Direction direction;
	private Vector3 leftTarget;
	private Vector3 rightTarget;
	private float journeyLength;
	private Vector3 originalPos;
	private float startTime;
	
	void Start () {
		direction = Direction.RIGHT;
		originalPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
		rightTarget = new Vector3(8.8f, originalPos.y, originalPos.z);
		leftTarget = new Vector3(-8.6f, originalPos.y, originalPos.z);
		startTime = Time.time;
		journeyLength = Vector3.Distance(leftTarget, rightTarget);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if (direction == Direction.LEFT) {
			transform.localPosition = Vector3.Lerp(originalPos, leftTarget, fracJourney);
		}
		else if (direction == Direction.RIGHT) {
			transform.localPosition = Vector3.Lerp(originalPos, rightTarget, fracJourney);
		}
		if (fracJourney >= 1f) {
			if (direction == Direction.LEFT) {
				direction = Direction.RIGHT;
				journeyLength = Vector3.Distance(transform.localPosition, rightTarget);
			}
			else if (direction == Direction.RIGHT) {
				direction = Direction.LEFT;
				journeyLength = Vector3.Distance(transform.localPosition, leftTarget);
			}
			originalPos.Set(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
			startTime = Time.time;
		}
	}
}