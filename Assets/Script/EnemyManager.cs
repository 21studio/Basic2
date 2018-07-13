using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	Transform playerTransform;

	public GameObject enemy;
	public float spawnTime = 2.0f;

	float deltaSpawnTime = 0.0f;
	int spawnCount = 0;

	List<GameObject> enemyPool = new List<GameObject>();
	int poolSize = 10;

	// Use this for initialization
	void Start () {
		// 아래 코드와 완전 동일
		// playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		playerTransform = GameObject.FindWithTag("Player").transform;

		for (int i=0; i < poolSize; ++i) {
			var obj = Instantiate(enemy);
			obj.name = "Enemy_" + i;
			obj.SetActive(false);

			enemyPool.Add(obj);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		deltaSpawnTime += Time.deltaTime;

		if (deltaSpawnTime > spawnTime && spawnCount <5) {
			deltaSpawnTime = 0.0f;

			//GameObject enemyObj = Instantiate(enemy) as GameObject;
			//spawnCount ++;
			//Debug.Log(spawnCount);

			var enemyObj = enemyPool.Find(x => x.activeSelf == false);
			if (enemyObj == null)
				return;

			enemyObj.SetActive(true);

			// for (int i=0; i < enemyPool.Count; ++i) {
			// 	if (enemyPool[i].activeSelf == false) {
			// 		enemyObj = enemyPool[i];
			// 		break;
			// 	}
			// }

			Vector3 spawnPos = playerTransform.forward * Random.Range(15.0f, 20.0f);
			spawnPos += playerTransform.right * Random.Range(-10.0f, 10.0f);
			spawnPos += playerTransform.position;
			spawnPos.y = 0.1f;

			enemyObj.transform.position = spawnPos;
		}
		
	}
}
