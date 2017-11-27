using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour {

    public EnemyInfo[] enemyInfos;

	void Start () {
        Instantiate(enemyInfos[Random.Range(0, enemyInfos.Length)], transform.position, Quaternion.identity, GameManager.instance.transform);
	}
}
