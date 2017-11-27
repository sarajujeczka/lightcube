using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    float one = 1;

    public float rotateRate = 0.75F;
    float nextRotate = 0.0F;
    WaitForSeconds wfs = new WaitForSeconds(0);

    public static Colour activeColor;
    public static bool isRotating = false;

    public Colour red, orange, yellow, green, blue, violett;
    public GameObject redImg, orangeImg, yellowImg, greenImg, blueImg, violettImg;

    void Start () {
        activeColor = red;
        redImg.GetComponent<ColourActivation>().Change(0);
        violettImg.GetComponent<ColourActivation>().Change(1);
        orangeImg.GetComponent<ColourActivation>().Change(2);
    }
	
	void Update () {
        if (Time.time > nextRotate && !isRotating) {
            if (Input.GetButtonDown("Previous")) {
                isRotating = true;
                nextRotate = Time.time + rotateRate;
                one = -1;
                StartCoroutine("DoRotation");
            }
            else if (Input.GetButtonDown("Next")) {
                isRotating = true;
                nextRotate = Time.time + rotateRate;
                one = 1;
                StartCoroutine("DoRotation");
            }
            
        }
        
    }

    IEnumerator DoRotation() {
        switch (activeColor.colour) {
            case Colours.Red:
                if (one == 1) {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = orange;
                    ResetImgs();
                    orangeImg.GetComponent<ColourActivation>().Change(0);
                    redImg.GetComponent<ColourActivation>().Change(1);
                    yellowImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, one * 45);
                    activeColor = violett;
                    ResetImgs();
                    violettImg.GetComponent<ColourActivation>().Change(0);
                    blueImg.GetComponent<ColourActivation>().Change(1);
                    redImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            case Colours.Orange:
                if (one == 1) {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = yellow;
                    ResetImgs();
                    yellowImg.GetComponent<ColourActivation>().Change(0);
                    orangeImg.GetComponent<ColourActivation>().Change(1);
                    greenImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = red;
                    ResetImgs();
                    redImg.GetComponent<ColourActivation>().Change(0);
                    violettImg.GetComponent<ColourActivation>().Change(1);
                    orangeImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            case Colours.Yellow:
                if (one == 1) {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = green;
                    ResetImgs();
                    greenImg.GetComponent<ColourActivation>().Change(0);
                    yellowImg.GetComponent<ColourActivation>().Change(1);
                    blueImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = orange;
                    ResetImgs();
                    orangeImg.GetComponent<ColourActivation>().Change(0);
                    redImg.GetComponent<ColourActivation>().Change(1);
                    yellowImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            case Colours.Green:
                if (one == 1) {
                    transform.Rotate(Vector3.right, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.right, one * 45);
                    activeColor = blue;
                    ResetImgs();
                    blueImg.GetComponent<ColourActivation>().Change(0);
                    greenImg.GetComponent<ColourActivation>().Change(1);
                    violettImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.up, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.up, one * 45);
                    activeColor = yellow;
                    ResetImgs();
                    yellowImg.GetComponent<ColourActivation>().Change(0);
                    orangeImg.GetComponent<ColourActivation>().Change(1);
                    greenImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            case Colours.Blue:
                if (one == 1) {
                    transform.Rotate(Vector3.forward, -one * 45);
                    wfs = new WaitForSeconds(rotateRate / 3);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, -one * 45);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, -one * 45);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, -one * 45);

                    activeColor = violett;
                    ResetImgs();
                    violettImg.GetComponent<ColourActivation>().Change(0);
                    blueImg.GetComponent<ColourActivation>().Change(1);
                    redImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.right, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.right, one * 45);
                    activeColor = green;
                    ResetImgs();
                    greenImg.GetComponent<ColourActivation>().Change(0);
                    yellowImg.GetComponent<ColourActivation>().Change(1);
                    blueImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            case Colours.Violett:
                if (one == 1) {
                    transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(rotateRate);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, one * 45);
                    activeColor = red;
                    ResetImgs();
                    redImg.GetComponent<ColourActivation>().Change(0);
                    violettImg.GetComponent<ColourActivation>().Change(1);
                    orangeImg.GetComponent<ColourActivation>().Change(2);
                }
                else {
                    transform.Rotate(Vector3.forward, one * 45);
                    wfs = new WaitForSeconds(rotateRate/3);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, one * 45);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, one * 45);
                    yield return wfs;
                    transform.Rotate(Vector3.forward, one * 45);
                    activeColor = blue;
                    ResetImgs();
                    blueImg.GetComponent<ColourActivation>().Change(0);
                    greenImg.GetComponent<ColourActivation>().Change(1);
                    violettImg.GetComponent<ColourActivation>().Change(2);
                }
                break;
            default:
                Debug.Log("An undefined input colour.");
                break;
        }
        yield return null;
        isRotating = false;
    }

    void ResetImgs() {
        redImg.GetComponent<ColourActivation>().Change(-1);
        orangeImg.GetComponent<ColourActivation>().Change(-1);
        yellowImg.GetComponent<ColourActivation>().Change(-1);
        greenImg.GetComponent<ColourActivation>().Change(-1);
        blueImg.GetComponent<ColourActivation>().Change(-1);
        violettImg.GetComponent<ColourActivation>().Change(-1);
    }

}