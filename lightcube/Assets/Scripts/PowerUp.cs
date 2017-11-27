using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public PickUps pickUp;

    private void OnTriggerEnter2D(Collider2D collision) {
        Player pl = collision.GetComponent<Player>();
        if (pl != null) {
            if (pickUp == PickUps.life) {
                pl.GetComponent<Player>().AddLife();
                Destroy(gameObject);
            }
            else {
                pl.AddPoints(2);
                Destroy(gameObject);
            }
        }
    }
}

public enum PickUps {
    life, points
}