using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	enum ENEMYSTATE {
		IDLE = 0,
		MOVE,
		ATTACK,
		DAMAGE,
		DEAD
	}

	ENEMYSTATE enemyState = ENEMYSTATE.IDLE;

	void Update () {
        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                {
                    // idle
                }
                break;
            case ENEMYSTATE.MOVE:
                {

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
