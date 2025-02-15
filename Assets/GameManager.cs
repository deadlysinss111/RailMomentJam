using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [NonSerialized] static public Action gameOver;

    [SerializeField] string loseSceneName;

    private void Awake()
    {
        gameOver += OnLose;
    }

    void OnLose()
    {
        SceneManager.LoadScene(loseSceneName);
    }
}
