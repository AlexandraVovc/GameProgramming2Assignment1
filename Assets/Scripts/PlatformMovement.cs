using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 5.0f;
    public float min = 2f;
    public float max = 3f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        min = transform.position.y;
        max = transform.position.y + 3;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }
}
