using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovements : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 5.0f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * Time.fixedDeltaTime * speed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}
