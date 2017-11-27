using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBrick : MonoBehaviour {
    public Colour[] colors;
    public Material desMat;
	void Start () {
        int i = Random.Range(0,3);
        if (i == 0) {
            gameObject.AddComponent<Brick>();
            this.enabled = false;
        }
        else if (i == 1) {
            gameObject.AddComponent<DestoyableBrick>();
            gameObject.GetComponent<DestoyableBrick>().mat = desMat;
            this.enabled = false;
        }
        else {
            gameObject.AddComponent<ColorBrick>();
            gameObject.GetComponent<ColorBrick>().myColor = colors[Random.Range(0, 6)];
            this.enabled = false;
        }
	}
	
}
