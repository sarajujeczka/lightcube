using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent, SelectionBase]
[RequireComponent(typeof(Enemy))]
public abstract class AI : MonoBehaviour {

    public Transform firePoint;
    protected Transform player;
    protected EnemyInfo info;
    protected Vector3 moveDirection;
    protected float nextFire = 0f;
    protected float nextThink = 0.1f;
    protected Colour myColour;

    public virtual void Start() {
        player = FindObjectOfType<Player>().transform;
        info = GetComponent<Enemy>().info;
        myColour = GetComponent<Enemy>().myColour;
    }

    public virtual void Update() {
        if (Time.time > nextThink && !Pause.active) {
            nextThink = Time.time + info.moveRate;
            Think();
        }
    }
    
    public virtual void Think() { }

    public virtual void Move(Vector3 direction) {
        transform.position = transform.position + direction;
    }

    public virtual void Flee() { }

    public virtual void Shoot(Transform firePoint, Vector2 direction) {
        Bullet bulletCopy = (Bullet)Instantiate(info.bullet, firePoint.position, Quaternion.identity);
        bulletCopy.myColour = myColour;
        bulletCopy.friendly = false;
        
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(direction * info.force);
    }
}


