using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour {

    private void OnMouseDown() {
        GetComponent<Animator>().SetTrigger("Animate");
    }
}
