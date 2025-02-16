using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] static public PlayerManager instance;
    int wallet = 0;
    int score = 0;
    float progress = 0;
    public int ballCount = 10;
    int ballToSpawn = 2;
    [SerializeField] private GameObject ball = null;
 
    public int Getscore()
    {
        return score;
    }
    public void upScore()
    {
        score++;
    }

    public int GetWallet()
    {
        return wallet;
    }
    public void UpWallet(wallet)
    {
        wallet++;
    }

    public void SetWallet(int _wallet)
    {
        wallet = _wallet;
    }

    public void SetScore(int _score)
    {
        score = _score;
    }
    void Start()
    {
        if (instance != null)
        {

            Destroy(this);
            return;
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           ballToSpawn = 2;
            Debug.Log("test");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ballToSpawn = 1;
            Debug.Log("test3");
        }
        //Debug.Log(ballCount);
    }

    public virtual float progressUpdate()
    {
        progress += Time.deltaTime;
        return progress;
    }
    public int GetBallCount()
    {
        return ballCount;
    }

    public void ChangeBallCount(int value)
    {
        ballCount += value;
    }

    public int GetBallToSpawn()
    {
        return ballToSpawn;
    }
}
