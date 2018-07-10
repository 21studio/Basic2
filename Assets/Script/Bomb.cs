using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject explosionParticle;
	bool isT;

	void Update () {
		if (Input.GetKeyDown(KeyCode.T) && !isT) {
			GetComponent<Rigidbody>().isKinematic = true;
			isT = true;
		}

		if (Input.GetKeyDown(KeyCode.T) && isT) {			
			GetComponent<Rigidbody>().isKinematic = false;
			isT = false;
		}
	}

	void OnCollisionEnter (Collision other) {
		
		var particleObj = Instantiate(explosionParticle); //as GameObject;
		particleObj.transform.position = transform.position;
		
		//Debug.Log("OnCollisionEnter : " + other.gameObject.name);
		Destroy(gameObject);
	}
}
