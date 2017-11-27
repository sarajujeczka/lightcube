using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : AI {

    public Transform checkUp, checkDown;

    Vector2 direction = new Vector2(1, 0);

    RaycastHit2D hit;
    float goodDistance = 1;

    public override void Start() {
        base.Start();
        transform.parent = GameManager.instance.transform;
        GameManager.instance.enemy++;
    }

    public override void Think() {
        if (transform.localPosition.x < GameManager.instance.minMove.x) {
            Move(new Vector3(1, 0, 0));
        }
        else {
            moveDirection = new Vector3(0, 0, 0);
            if (transform.position.y == player.position.y) {
                if (Time.time > nextFire && transform.position.x < player.position.x) {
                    nextFire = Time.time + info.fireRate;
                    Shoot(firePoint, direction);
                }
                else if (Rotate.activeColor == myColour) {
                    if (transform.localPosition.y > GameManager.instance.minMove.y)
                        moveDirection = new Vector3(0, -1, 0);
                    else
                        moveDirection = new Vector3(0, 1, 0);
                }
            }
            else {
                if (transform.position.y < player.position.y) {
                    hit = Physics2D.Raycast(checkUp.position, transform.up, goodDistance);
                    if (hit.collider == null) {
                        if (transform.localPosition.y >= GameManager.instance.minMove.y &&
                            transform.localPosition.y <= GameManager.instance.maxMove.y) {
                            moveDirection = new Vector3(0, 1, 0);
                        }
                    } 
                }
                else {
                    hit = Physics2D.Raycast(checkDown.position, -transform.up, goodDistance);
                    if (hit.collider == null) {
                        if (transform.localPosition.y >= GameManager.instance.minMove.y &&
                            transform.localPosition.y <= GameManager.instance.maxMove.y) {
                            moveDirection = new Vector3(0, -1, 0);
                        }
                    } 
                }
            }
            Move(moveDirection);
        }
    }


}