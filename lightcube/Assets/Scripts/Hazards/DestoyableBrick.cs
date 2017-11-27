using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableBrick : Brick {

    public Material mat;
    public GameObject particalSystem;

    private void Start() {
        GetComponent<Renderer>().material = mat;
    }

    public override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);
        Bullet bu = collision.GetComponent<Bullet>();
        if (bu != null && bu.friendly) {
            Instantiate(particalSystem, transform.position, transform.rotation);
            FindObjectOfType<Player>().AddPoints(0.2f);
            Death();
            Destroy(gameObject);
        }
    }
    
}
