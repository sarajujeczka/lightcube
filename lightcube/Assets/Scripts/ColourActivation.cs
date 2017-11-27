using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourActivation : MonoBehaviour {

    public GameObject active, prev, next;

    public void Change(int i) {
        switch (i) {
            case 0:
                active.SetActive(true);
                prev.SetActive(false);
                next.SetActive(false);
                break;
            case 1:
                active.SetActive(false);
                prev.SetActive(true);
                next.SetActive(false);
                break;
            case 2:
                active.SetActive(false);
                prev.SetActive(false);
                next.SetActive(true);
                break;
            default:
                active.SetActive(false);
                prev.SetActive(false);
                next.SetActive(false);
                break;
        }
    }
}
