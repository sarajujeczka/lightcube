using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotation : MonoBehaviour {

    float nextMove = 0;
    public float moveRate = 0.5f;
    public float angle = 45;

    void Start () {
		
	}

	void Update () {
        if (Time.time > nextMove) {
            nextMove = Time.time + moveRate;
            transform.Rotate(Vector3.up, angle);
        }
    }
}
