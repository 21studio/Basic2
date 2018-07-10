using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float sensitivity = 700.0f;
	float rotationX;
	float rotationY;
	
	// Update is called once per frame
	void Update () {
		
		float mouseMoveValueX = Input.GetAxis("Mouse X");
		float mouseMoveValueY = Input.GetAxis("Mouse Y");

		rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
		rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

		rotationX %= 360;
		rotationY %= 360;
		
		//Debug.Log("rotation X : " + rotationX + " / " + "rotation Y : " + rotationY, gameObject);
		
		rotationX = Mathf.Clamp(rotationX, -27f, 27f);
		 
		// if (rotationX > 27) {
		// 	rotationX = 27;
		// }
		// else if (rotationX < -27) {
		// 	rotationX = -27;
		// }
		
		transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);

		// if (Input.GetKeyDown(KeyCode.A)) {
		// 	Debug.LogWarning("Warning");
		// }
		// if (Input.GetKeyDown(KeyCode.B)) {
		// 	Debug.LogError("Error");
		// }

	}
}
