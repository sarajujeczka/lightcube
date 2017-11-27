using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff : MonoBehaviour {
    public Transform[] stuff;
    public Vector3 minPosition, maxPosition;

    void Start () {
        RandomizeStuff();
    }

    public void RandomizeStuff() {
        for (int i = 0; i < stuff.Length; i++) {
            stuff[i].Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            stuff[i].position = transform.position + new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
            
        }
    }
}
