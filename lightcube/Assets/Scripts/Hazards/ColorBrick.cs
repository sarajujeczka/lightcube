using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBrick : Brick {

    public Colour myColor;

    private void Start() {
        GetComponent<Renderer>().material = myColor.matEmit;
    }

    public override void OnTriggerEnter2D(Collider2D collision) {
        Player pl = collision.GetComponent<Player>();
        if (pl != null) {
            if (Rotate.activeColor != myColor) {
                pl.Hit(0.5f);
            }
            else {
                Death();
            }
        }

        Bullet bu = collision.GetComponent<Bullet>();
        if (bu != null && bu.friendly) {
            if (bu.GetComponent<Bullet>().myColour == myColor) {
                Instantiate(myColor.particleSystem, transform.position, transform.rotation);
                FindObjectOfType<Player>().AddPoints(1);
                Destroy(gameObject);
            }
        }
    }


}
