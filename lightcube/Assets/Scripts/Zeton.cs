using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeton : MonoBehaviour {

    public GameObject canvas;

    bool active = false;

    private void OnMouseDown() {
        active = !active;
        GetComponent<Animator>().SetTrigger("Animate");
        canvas.SetActive(active);
    }

    void Update () {
        transform.Rotate(transform.up, 3);
	}

    public void ButtonPressed(string website) {
        Application.OpenURL(website);
    }
}
