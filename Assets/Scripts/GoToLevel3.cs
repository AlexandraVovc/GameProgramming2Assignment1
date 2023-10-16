using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel3 : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    void Start()
    {
        playerPosition = player.transform.position;

        CharacterMovement.buildIndex = 3;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level 3");
        }

    }
}
