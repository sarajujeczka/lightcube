using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour {

    public Transform sib;
    public float distance = 40;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Ping")) {
            sib.position = new Vector3(transform.position.x - distance, 15, 0);
            GameManager.instance.ReadMap();
        }
        
    }
}
