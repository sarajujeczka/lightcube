using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent, SelectionBase]
public class Player : MonoBehaviour {

    float health = 1f;
    public int lifes = 3;

    public GameObject[] heartSlots = new GameObject[3];
    public Slider healthSlider;
    public Text score;
    public GameObject canvas;
    public int scoreValue = 0;

    public bool unhittble = false;
    public bool isDead = false;
    public GameObject dead;

    public Rotate rotate;
    public MeshRenderer mr;

    public void Hit() {
        if(!unhittble)
            health -= 0.35f;
        if (health <= 0) {
            health = 0;
            Death();
        }
        healthSlider.value = health;
    }

    public void Hit(float value) {
        if(!unhittble)
            health -= value;
        if (health <= 0) {
            health = 0;
            Death();
        }
        healthSlider.value = health;
    }

    public void Heal(float value) {
        health += value;
        if (health >= 1) {
            health = 1;
        }
        healthSlider.value = health;
    }

    public void AddLife() {
        if (lifes < 3) {
            lifes++;
            heartSlots[lifes - 1].SetActive(true);
        }
        else
            Heal(1);
    }

    public void AddPoints(float value) {
        scoreValue += (int)(value * 100 * lifes);
        score.text = scoreValue.ToString();
    }

    void Death() {
        isDead = true;
        GameObject go = Instantiate(dead, transform.position, rotate.gameObject.transform.rotation);
        go.SetActive(true);
        DeadEffects();
        
        if (lifes == 0) {
            ResetMap();
        }
        else {
            health = 1;
            lifes--;
            healthSlider.value = health;
            heartSlots[lifes].SetActive(false);
            Invoke("DeadEffects", 5f);
        }            
    }

    void DeadEffects() {
        GetComponent<Movement>().enabled = !isDead;
        GetComponentInChildren<Attack>().enabled = !isDead;
        GameManager.instance.shouldSpawn = !isDead;
        mr.enabled= !isDead;
        GetComponent<BoxCollider2D>().enabled = !isDead;
        GetComponent<TrailRenderer>().enabled = !isDead;
        if (isDead)
            isDead = false;
    }

    void ResetMap() {
        canvas.gameObject.SetActive(false);
        GameManager.instance.EndGame();
    }

    public void StopYourself(bool shouldStop) {
        GetComponent<Movement>().enabled = !shouldStop;
        GetComponentInChildren<Attack>().enabled = !shouldStop;
        rotate.enabled = !shouldStop;
        canvas.SetActive(!shouldStop);
    }
}
