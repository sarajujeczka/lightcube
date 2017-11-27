using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public bool isFree = true;
    public float moveSpeed, rotationSpeed;
    public Vector3 rotationPoint;


	void Update () {
        transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
    }

    /// <summary>
    /// Setting the Cube.
    /// </summary>
    /// <param name="move">Move Speed</param>
    /// <param name="rotation">Rotation Speed</param>
    /// <param name="life">Life Expectancy</param>
    /// <param name="pointOfRotation">Rotation Point</param>
    public void SetCube(float move, float rotation, float life, Vector3 pointOfRotation) {
        moveSpeed = move;
        rotationSpeed = rotation;
        rotationPoint = pointOfRotation;
        Invoke("StopMoving", life);
        isFree = false;
    }

    void StopMoving() {
        isFree = true;
    }
}
