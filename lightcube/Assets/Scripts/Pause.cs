using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject canvas;
    public Text score;

    public static bool active = false;

    Player player;

	void Start () {
        player = FindObjectOfType<Player>();
	}
	

	void Update () {
        if (Input.GetButtonDown("Pause")) {
            SetPause();
        }
	}

    public void SetPause() {
        active = !active;
        player.StopYourself(active);
        canvas.SetActive(active);
        score.text = "YOUR SCORE: " + player.scoreValue.ToString();
    }
}
