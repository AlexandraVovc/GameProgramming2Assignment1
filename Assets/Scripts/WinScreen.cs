using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    void Start()
    {
        playerPosition = player.transform.position;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }

    }
}
