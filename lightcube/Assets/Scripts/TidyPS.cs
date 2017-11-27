using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyPS : MonoBehaviour {

    public float removeTime = 3.0f;

    void Start() {
        Destroy(gameObject, removeTime);
    }
}
