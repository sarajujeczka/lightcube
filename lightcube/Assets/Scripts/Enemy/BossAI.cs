using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : AI {

    public Transform firePoint2;
    public Colour red, orange, yellow, green, blue, violett;
    public static bool isRotating = false;
    public BoxCollider2D colorBC;
    public Transform body;

    ParticleSystem gunParticles1, gunParticles2;
    Light gunLight1, gunLight2;
    AudioSource gunAudio1, gunAudio2;
    Bullet bulletCopy1, bulletCopy2;

    public static Colour activeColor;
    float one = 1, random;
    WaitForSeconds wfs = new WaitForSeconds(0);
    public static bool shouldRotate = false;

    Boss boss;

    public override void Start() {
        base.Start();
        boss = GetComponent<Boss>();
        activeColor = yellow;
        boss.CanShoot();
        transform.parent = GameManager.instance.transform;
        gunParticles1 = firePoint.GetChild(0).GetComponent<ParticleSystem>();
        gunAudio1 = firePoint.GetChild(0).GetComponent<AudioSource>();
        gunLight1 = firePoint.GetChild(0).GetComponent<Light>();
        gunParticles2 = firePoint2.GetChild(0).GetComponent<ParticleSystem>();
        gunAudio2 = firePoint2.GetChild(0).GetComponent<AudioSource>();
        gunLight2 = firePoint2.GetChild(0).GetComponent<Light>();
    }

    public override void Think() {
        base.Think();
        if (!isRotating) {
            random = Random.Range(0.0f, 1.0f);
            moveDirection = new Vector3(0, 0, 0);
            if (transform.localPosition.x < GameManager.instance.minMove.x + 2) {
                Move(new Vector3(1, 0, 0));
            }
            else if (shouldRotate || random >= 0.5f) {
                random = Random.Range(0.0f, 1.0f);
                one = (random <= 0.5f) ? 1 : -1;
                StartCoroutine("DoRotation");
            }
            else if (transform.position.y == player.position.y && boss.canShoot) {
                if (Time.time > nextFire && transform.position.x < player.position.x) {
                    nextFire = Time.time + info.fireRate;
                    Shoot();
                }
            }
            else if (transform.position.y < player.position.y) {
                moveDirection = new Vector3(0, 1, 0);
            }
            else if (transform.position.y > player.position.y) {
                moveDirection = new Vector3(0, -1, 0);
            }
            
            else {
                random = Random.Range(0.0f, 1.0f);
                one = (random <= 0.5f) ? 1 : -1;
                StartCoroutine("DoRotation");
            }
            Move(moveDirection);
        }
        
    }


    IEnumerator DoRotation() {
        colorBC.enabled = false;
        isRotating = true;
        switch (activeColor.colour) {
            case Colours.Red:
                if (one == 1) {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = orange;
                }
                else {
                    body.transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, one * 45);
                    activeColor = violett;
                }
                break;
            case Colours.Orange:
                if (one == 1) {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = yellow;
                }
                else {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = red;
                }
                break;
            case Colours.Yellow:
                if (one == 1) {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = green;
                }
                else {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = orange;
                }
                break;
            case Colours.Green:
                if (one == 1) {
                    body.transform.Rotate(Vector3.right, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.right, one * 45);
                    activeColor = blue;
                }
                else {
                    body.transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.up, one * 45);
                    activeColor = yellow;
                }
                break;
            case Colours.Blue:
                if (one == 1) {
                    body.transform.Rotate(Vector3.forward, -one * 45);
                    wfs = new WaitForSeconds(info.moveRate / 3);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, -one * 45);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, -one * 45);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, -one * 45);

                    activeColor = violett;
                }
                else {
                    body.transform.Rotate(Vector3.right, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.right, one * 45);
                    activeColor = green;
                }
                break;
            case Colours.Violett:
                if (one == 1) {
                    body.transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(info.moveRate);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, one * 45);
                    activeColor = red;
                }
                else {
                    body.transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(info.moveRate / 3);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, one * 45);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, one * 45);
                    yield return wfs;
                    body.transform.Rotate(Vector3.forward, one * 45);
                    activeColor = blue;
                }
                break;
            default:
                break;
        }
        boss.CanShoot();
        yield return null;
        isRotating = false;
        colorBC.enabled = true;
        shouldRotate = false;
    }

    void Shoot() {
        gunAudio1.Play();
        gunAudio2.Play();

        gunLight1.enabled = true;
        gunLight2.enabled = true;

        gunParticles1.Stop();
        gunParticles1.Play();
        gunParticles2.Stop();
        gunParticles2.Play();

        bulletCopy1 = (Bullet)Instantiate(info.bullet, firePoint.position, Quaternion.identity);
        bulletCopy1.friendly = false;
        bulletCopy1.boss = true;
        bulletCopy1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * info.force);
        bulletCopy2 = (Bullet)Instantiate(info.bullet, firePoint2.position, Quaternion.identity);
        bulletCopy2.friendly = false;
        bulletCopy2.boss = true;
        bulletCopy2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * info.force);
        Invoke("DisableEffects", 0.07f);
    }

    void DisableEffects() {
        gunLight1.enabled = false;
        gunLight2.enabled = false;
    }

}
