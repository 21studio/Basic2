using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject.name.Contains("Player")) {
            other.transform.position = new Vector3(0, 50, 0);

		}
		else if (other.gameObject.name.Contains("Ball")) {
			Destroy(other.gameObject);
		}
	}
}
