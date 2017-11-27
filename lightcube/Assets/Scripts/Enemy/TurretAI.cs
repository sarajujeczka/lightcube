using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : AI {

    public Transform firePoint2;

    float distance = 15f;
    float goodDistance = 1;
    Vector2 direction = new Vector2(1, 0);
    Vector2 direction2 = new Vector2(0, 1);

    bool shoot1 = true, shoot2 = true;
    RaycastHit2D hit;

    public override void Start() {
        base.Start();
        shoot2 = transform.position.y < GameManager.instance.maxMove.y;
        hit = Physics2D.Raycast(firePoint2.position, transform.up, goodDistance);
        if (hit.collider != null) {
            shoot2 = false;
        }
        hit = Physics2D.Raycast(firePoint2.position, Vector2.right, goodDistance);
        if (hit.collider != null) {
            shoot1 = false;
        }
    }

    public override void Think() {
        if ((player.transform.position - transform.position).sqrMagnitude < distance * distance) {
            if (shoot1)
                Shoot(firePoint, direction);
            if (shoot2)
                Shoot(firePoint2, direction2); 
        }
    }
}
