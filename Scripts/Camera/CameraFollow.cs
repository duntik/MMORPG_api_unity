using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
