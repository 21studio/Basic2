using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;
    public Animation anim;

    Transform target = null;
    CharacterController characterController = null;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 2.5f;

	enum ENEMYSTATE {
		IDLE = 0,
		MOVE,
		ATTACK,
		DAMAGE,
		DEAD
	}

	ENEMYSTATE enemyState = ENEMYSTATE.IDLE;

	void Awake () {
        InitZombie();
    }

    void Start () {
        target = GameObject.FindWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();
    }

    void InitZombie() {
        enemyState = ENEMYSTATE.IDLE;
        PlayIdleAnim();
    }

    void PlayIdleAnim() {
        anim["Idle"].speed = 3.0f;
        anim.Play("Idle");
    }
    
    void Update () {
        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                {
                    stateTime += Time.deltaTime;
                    if (stateTime > idleStateMaxTime) {
                        stateTime = 0.0f;
                        enemyState = ENEMYSTATE.MOVE;
                    }
                }
                break;
            case ENEMYSTATE.MOVE:
                {
                    anim["Move"].speed = 2.0f;
                    anim.CrossFade("Move");

                    float distance = (target.position - transform.position).magnitude;
                    if (distance < attackRange) {
                        enemyState = ENEMYSTATE.ATTACK;
                    }
                    else {
                        Vector3 dir = target.position - transform.position;
                        dir.y = 0.0f;
                        dir.Normalize();
                        characterController.SimpleMove(dir * moveSpeed);

                        transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                    }
                }
                break;
            case ENEMYSTATE.ATTACK:
                {

                }
                break;
            case ENEMYSTATE.DAMAGE:
                {

                }
                break;
            case ENEMYSTATE.DEAD:
                {

                }
                break;
        }
	}
}
