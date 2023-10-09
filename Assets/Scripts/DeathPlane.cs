using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    void Start()
    {
        playerPosition = player.transform.position;
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
