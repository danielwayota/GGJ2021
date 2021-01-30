using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 2;

    void Update()
    {
        if (this.target is null)
            return;

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            target.position + this.offset,
            Time.deltaTime * this.speed
        );
    }
}
