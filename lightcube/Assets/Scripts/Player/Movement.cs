using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        if (Input.GetButtonDown("Up") && transform.position.y < GameManager.instance.transform.position.y + GameManager.instance.maxMove.y) {
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
        if (Input.GetButtonDown("Down") && transform.position.y > GameManager.instance.transform.position.y + GameManager.instance.minMove.y) {
            transform.position = transform.position + new Vector3(0, -1, 0);
        }
        if (Input.GetButtonDown("Back") && transform.position.x < GameManager.instance.transform.position.x + GameManager.instance.maxMove.x) {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }
        if (Input.GetButtonDown("Forward") && transform.position.x > GameManager.instance.transform.position.x + GameManager.instance.minMove.x) {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if (transform.position.z != 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), 0);
    }
}
