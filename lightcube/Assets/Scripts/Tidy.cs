using UnityEngine;
using System.Collections;

public class Tidy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Brick>() || collision.gameObject.GetComponent<Enemy>() || 
            collision.gameObject.GetComponent<Bullet>() || collision.gameObject.GetComponent<PowerUp>()) {
            Destroy(collision.gameObject);
        }
    }

}
