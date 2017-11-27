using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public virtual void OnTriggerEnter2D(Collider2D collision) {
        Player pl = collision.GetComponent<Player>();
        if (pl != null) {
            pl.Hit(0.5f);
        }
    }

    public virtual void Death() {

    }
}
