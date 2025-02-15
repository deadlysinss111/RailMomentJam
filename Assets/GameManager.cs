using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string playerTag = "Player Life";
    public string defeatSceneName = "DefeatScene";
    [NonSerialized] static public Action gameOver;
    private GameObject playerLifeObject;
    [SerializeField] string loseSceneName;

    void OnLose()
    {
        SceneManager.LoadScene(loseSceneName);
    }

    void Start()
    {
        gameOver += OnLose;
        playerLifeObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerLifeObject == null)
        {
            Debug.LogError("Aucun objet avec le tag 'Player collision' n'a été trouvé !");
        }
    }

    void Update()
    {
        if (playerLifeObject == null)
        {
            Debug.Log("About to laod scene");
            SceneManager.LoadScene(defeatSceneName, LoadSceneMode.Single);
        }
    }
}
