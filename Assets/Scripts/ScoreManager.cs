using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

    public int Score = 0;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        scoreText.text = Score.ToString() + " Points";
    }

    private void Update () {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        Score += 50;
        scoreText.text = Score.ToString() + " Points";
    }
}
