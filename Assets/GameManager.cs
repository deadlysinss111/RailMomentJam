using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
