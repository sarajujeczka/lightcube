using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour {

    public Colour myColour;
    public bool friendly = true;
    public bool boss = false;
    public GameObject particleSys;
    float lifeExpectancy = 4f;

    Bullet bullet;
    Enemy enemy;
    Player player;
    Brick brick;
    Vector3 position;
    static bool a = true;

    private void Start() {
        if (friendly) {
            myColour = Rotate.activeColor;
        }
        if (boss) {
            myColour = BossAI.activeColor;
        }
        GetComponent<Renderer>().material = myColour.matEmit;

        Invoke("Death", lifeExpectancy);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null && friendly != bullet.friendly) {
            Death();
        }

        if (friendly) {
            enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.Hit(myColour);
                Death();
            }
        }
        else {
            player = collision.gameObject.GetComponent<Player>();
            if (player != null) {
                player.Hit();
                Death();
            }
            enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null) {
                Death();
            }
        }

        brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null) {
            Death();
        }


    }

    private void Update() {
        if (Pause.active) {
            if (a) {
                a = false;
                position = transform.position;
            }
            transform.position = position;
        }
        if (!Pause.active && !a) {
            a = true;
        }
    }

    void Death() {
        Instantiate(particleSys, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
