using UnityEngine;
using System.Collections;

public class ReturnToMenuScript : MonoBehaviour {
	public int targetLevel;

	void Update () {
		if (Input.GetAxis ("Escape") > 0) {
			Application.LoadLevel (targetLevel);
		}
	}
}
