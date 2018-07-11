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

    public float attackStateMaxTime = 2.0f;

    public int healthPoint = 5;

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
                    //Debug.Log("stateTime :" + stateTime);
                    
                    if (stateTime > idleStateMaxTime)
                    {
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
                        stateTime = attackStateMaxTime;
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
                    stateTime += Time.deltaTime;
                    if (stateTime > attackStateMaxTime) {
                        stateTime = 0.0f;
                        anim["Attack"].speed = -0.5f;
                        anim["Attack"].time = anim["Attack"].length;
                        anim.Play("Attack");
                    }

                    float distance = Vector3.Distance(target.position, transform.position);
                    //float distance = (target.position - transform.position).magnitude;
                    if (distance > attackRange) {
                        enemyState = ENEMYSTATE.IDLE;
                    }
                }
                break;
            case ENEMYSTATE.DAMAGE:
                {
                    healthPoint -= 1;
                    Debug.Log ("HP : " + healthPoint);

                    AnimationState animState = anim.PlayQueued("Damage", QueueMode.PlayNow);
                    animState.speed = 2.0f;

                    float animLength = anim["Damage"].length / animState.speed;
                    CancelInvoke();
                    Invoke("PlayIdleFromDamage", animLength);

                    stateTime = 0.0f;
                    enemyState = ENEMYSTATE.MOVE;

                    if(healthPoint <= 0)
                    enemyState = ENEMYSTATE.DEAD;
                }
                break;
            case ENEMYSTATE.DEAD:
                {
                    //anim.Play("Death");
                    Destroy(gameObject);
                }
                break;
        }
	}

    void OnCollisionEnter (Collision other) {
        
        if (other.gameObject.CompareTag("Ball") == false)
        //if (other.gameObject.tag != "Ball")
            return;
        
        enemyState = ENEMYSTATE.DAMAGE;
    }

    void PlayIdleFromDamage() {
        anim.CrossFade("Idle");
    }
}
