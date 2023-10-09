using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    public CharacterMovement characterMovement;
    Rigidbody rigidBody;
    public float speed = 5.0f;
    public GameObject particleSystemPrefab;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * Time.fixedDeltaTime * speed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            characterMovement.canDoubleJump = true;
            Invoke("UnhideTarget", 30.0f);
            Instantiate(particleSystemPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);            
        }
    }

    public void UnhideTarget()
    {
        gameObject.SetActive(true);
    }
}
