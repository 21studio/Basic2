using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	Vector3 localPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		localPosition = transform.localPosition;
	}
	
	Coroutine coroutine;
	public void PlayCameraShake() {
		
		if (coroutine != null) {
			StopCoroutine(coroutine);
			coroutine = null;
		}
		
		//StopAllCoroutines();
		coroutine = StartCoroutine(CameraShakeProcess(0.2f, 0.1f));
	}

	IEnumerator CameraShakeProcess(float shakeTime, float shakeSense) {
		float deltaTime = 0.0f;

		while(deltaTime < shakeTime) {
			deltaTime += Time.deltaTime;

			transform.localPosition = localPosition;
			Vector3 pos = Vector3.zero;
			pos.x = Random.Range( -shakeSense, shakeSense);
			pos.y = Random.Range( -shakeSense, shakeSense);
			pos.z = Random.Range( -shakeSense, shakeSense);
			transform.localPosition += pos;

			yield return new WaitForEndOfFrame();
		}

		transform.localPosition = localPosition;
		yield return null;
	}
}
