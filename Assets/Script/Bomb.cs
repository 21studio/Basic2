﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject explosionParticle;
	public GameObject explosionParticleAir;

	bool isKinematic = false;
		 
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			isKinematic = !isKinematic;
		
			if (isKinematic == true)
				GetComponent<Rigidbody>().isKinematic = true;
			else
				GetComponent<Rigidbody>().isKinematic = false;			
		}		
	}

	void OnCollisionEnter (Collision other) {

		SoundManager.instance.PlaySFX(SFX.BOMB);
		
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			var particleObj = Instantiate(explosionParticle); //as GameObject;
			particleObj.transform.position = transform.position;
		}
		
		else if (other.gameObject.name.Contains("Ball")) {
			var particleObjAir = Instantiate(explosionParticleAir); //as GameObject;
			particleObjAir.transform.position = transform.position;
		}

		else {
			var particleObjAir = Instantiate(explosionParticleAir); //as GameObject;
			particleObjAir.transform.position = transform.position;	
		}		
		
		//Debug.Log("OnCollisionEnter : " + other.gameObject.name);
		Destroy(gameObject);
	}

	

}
