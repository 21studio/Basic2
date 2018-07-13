using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

	public Animator anim;

	public void Idle() {
		anim.SetBool("move", false);
	}

	public void Move() {
		anim.SetBool("move", true);
	}

	public void Jump() {
		anim.Play("Jump");
	}
	
	public void Grounded() {
		anim.SetTrigger("grounded");
	}

	public void Damage() {
		anim.SetTrigger("damage");
	}

	public void Dead() {
		anim.SetTrigger("dead");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
