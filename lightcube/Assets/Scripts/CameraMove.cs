using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class CameraMove : MonoBehaviour {

    public Transform target;

    Vector3 offset;
    Vector3 desiredPosition;
    Vector3 position;

    public float damping = 5;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        desiredPosition = target.position + offset;
        position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;
    }
}