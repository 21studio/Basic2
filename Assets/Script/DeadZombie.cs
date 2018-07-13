using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZombie : MonoBehaviour {

	public Rigidbody rb;
	public MeshCollider meshCollider;
	public float downSpeed = 0.5f;

	IEnumerator Start () {
		while (rb.velocity != Vector3.zero) {
			yield return new WaitForEndOfFrame();			
		}

		rb.isKinematic = true;
		meshCollider.isTrigger = true;

		while (transform.position.y > -2.0f) {
			Vector3 temp = transform.position;
			temp.y -= downSpeed * Time.deltaTime;
			transform.position = temp;

			yield return new WaitForEndOfFrame();
		}

		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
