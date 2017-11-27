using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public Shield[] shields;

    public bool canShoot = false;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    public override void Hit(Colour colour) {
        myColour = BossAI.activeColor;
        if (colour == myColour) {
            for (int i = 0; i < shields.Length; i++) {
                if (shields[i].colour == myColour) {
                    if (shields[i].active) {
                        shields[i].health -= 0.35f;
                        if (shields[i].health <= 0) {
                            ColourDestroy(shields[i]);
                            shields[i].active = false;
                        }
                    }
                    else {
                        health -= 0.5f;
                    }
                }
            }
            BossAI.shouldRotate = true;
        }
        else
            health -= 0.5f;
        
        if (health <= 0) {
            Death();
        }
    }

    void ColourDestroy(Shield obj) {
        player.AddPoints(10);
        Instantiate(obj.colour.particleSystem, obj.obj.transform.position, Quaternion.identity);
        Destroy(obj.obj.gameObject);
    }

    public void CanShoot() {
        myColour = BossAI.activeColor;
        for (int i = 0; i < shields.Length; i++) {
            if (shields[i].colour == myColour) {
                canShoot = shields[i].active;
                if (!canShoot) {
                    BossAI.shouldRotate = true;
                }
            }
        }
    }

    public override void Death() {
        GameManager.instance.WinGame();
        player.AddPoints(20);
        for (int i = 0; i < shields.Length; i++) {
            Instantiate(shields[i].particleSystem, shields[i].obj.transform.position, Quaternion.identity);
        }
        GetComponent<AI>().enabled = false;
        Destroy(gameObject);
    }

}

[System.Serializable]
public class Shield {
    public string name;
    public float health = 1;
    public GameObject obj;
    public Colour colour;
    public bool active = true;
    public GameObject particleSystem;
}