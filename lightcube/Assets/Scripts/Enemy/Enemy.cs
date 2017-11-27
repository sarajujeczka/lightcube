using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 1;
    public EnemyInfo info;
    public Renderer inside;
    public Rigidbody outside;

    public Colour myColour;
    protected Player player;

    void Start () {
        if (myColour == null) {
            myColour = info.colours[Random.Range(0, info.colours.Length)];
        }
        AssignColor(myColour);
        player = FindObjectOfType<Player>();
    }

    public virtual void Hit(Colour colour) {
        if (colour == myColour) {
            player.AddPoints(1);
            Death();
        }
        if (health <= 0) {
            player.AddPoints(0.3f);
            Death();
        }
        if (colour.nextColour.colour == myColour.colour || colour.prevColour.colour == myColour.colour) {
            health -= 0.35f;
            transform.position -= new Vector3(1,0,0);
        }
        else if (colour.nextColour.nextColour.colour == myColour.colour || colour.prevColour.prevColour.colour == myColour.colour) {
            transform.position -= new Vector3(0.5f, 0, 0);
        }
        
    }

    public virtual void Death() {        
        inside.material = myColour.material;
        inside.GetComponent<Rigidbody>().isKinematic = false;
        inside.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 10f);
        outside.isKinematic = false;
        outside.AddForce(new Vector3(0, 0, -900f));
        if (GetComponent<BasicAI>())
            GameManager.instance.enemy--;
        GetComponent<AI>().enabled = false;
        Destroy(gameObject, 3f);
    }

    public void AssignColor(Colour colour) {
        myColour = colour;
        inside.material = myColour.matEmit;
    }

}
