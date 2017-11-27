using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Bullet bullet;
    public float fireRate = 0.75F;
    float force = 70f;
    float nextFire = 0.0F;

    ParticleSystem gunParticles;
    Light gunLight;
    AudioSource gunAudio;

    void Start() {
        gunParticles = transform.GetChild(0).GetComponent<ParticleSystem>();
        gunAudio = transform.GetChild(0).GetComponent<AudioSource>();
        gunLight = transform.GetChild(0).GetComponent<Light>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire && !Rotate.isRotating) {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        //else if (Input.GetKeyDown(KeyCode.P) && Time.time > nextFire) {
        //    nextFire = Time.time + fireRate;

        //}
    }

    void Shoot() {
        gunAudio.Play();
        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        Bullet bulletCopy = (Bullet)Instantiate(bullet, transform.position, Quaternion.identity);
        bulletCopy.friendly = true;
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,0) * force);
        Invoke("DisableEffects", 0.07f);
    }

    void DisableEffects() {
        gunLight.enabled = false;
    }
}
