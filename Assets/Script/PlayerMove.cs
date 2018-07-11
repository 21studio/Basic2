using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	CharacterController characterController = null;

	public Transform cameraTransform;
	public float moveSpeed = 10.0f;

	public float jumpSpeed = 10.0f;
	public float gravity = -20.0f;

	float yVelocity = 0.0f;
	int jumpCount = 0;
	
	void Start () {
		characterController = GetComponent<CharacterController>();
	}

	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(x, 0, z);
		moveDirection = cameraTransform.TransformDirection(moveDirection);
		moveDirection *= moveSpeed;

		if (characterController.isGrounded == true) {
			yVelocity = 0.0f;
			jumpCount = 0;
		}
		//Debug.Log(characterController.isGrounded);
		
		if (Input.GetButtonDown("Jump") && jumpCount < 2) {
			yVelocity = jumpSpeed;
			
			++jumpCount;
		}

		yVelocity += (gravity * Time.deltaTime);
		moveDirection.y = yVelocity;

		//Debug.Log(yVelocity);

		characterController.Move(moveDirection * Time.deltaTime);
		
	}
}
