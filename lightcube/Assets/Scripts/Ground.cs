using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public Transform sib;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Ping")) {
            sib.position = new Vector3(transform.position.x - 300f, transform.position.y, transform.position.z);
            sib.GetComponentInChildren<Stuff>().RandomizeStuff();
        }
    }

    private void Update() {
        if(GameManager.instance.worldSpeed != 0 && !Pause.active)
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
