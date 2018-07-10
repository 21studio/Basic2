﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	public Transform cameraTransform;
	public GameObject fireObject;
	public float forwardPower = 20.0f;
	public float upPower = 1.0f;

	public Transform firePosTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			GameObject obj = Instantiate(fireObject) as GameObject;

			float rnd = Random.Range(-180.0f, 180.0f);
			
			obj.transform.position = firePosTransform.position;
			obj.GetComponent<Rigidbody>().velocity = (cameraTransform.forward * forwardPower) + (Vector3.up * upPower);
			
			obj.GetComponent<Rigidbody>().AddTorque(rnd, rnd, rnd);
			//Quaternion rot = Quaternion.Euler(rnd, rnd, rnd);
			//obj.GetComponent<Rigidbody>().MoveRotation(obj.GetComponent<Rigidbody>().rotation * rot);
			
			//Debug.Log(rnd);
		}
	}
}
