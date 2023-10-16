using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    public CharacterMovement characterMovement;
    Rigidbody rigidBody;
    public float speed = 5.0f;
    public GameObject particleSystemPrefab;
    public ScoreManager Score;

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
            Instantiate(particleSystemPrefab, transform.position, transform.rotation);
            Score.IncrementScore();
            gameObject.SetActive(false);
        }
    }
}
