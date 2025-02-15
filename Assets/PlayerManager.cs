using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] static public PlayerManager instance;
    int score = 0;
    float progress = 0;
    public int ballCount = 10;
    int ballToSpawn = 2;
    [SerializeField] private GameObject ball = null;
    public int nbSpawnBalloon = 1;

    public int GetNBSpawnBalloon()
    {
        return nbSpawnBalloon;
    }

    public void SetNBBalloon(int nb)
    {
        nbSpawnBalloon = nb;
    }
 
    public int Getscore()
    {
        return score;
    }
    public void upScore()
    {
        score++;
    }
    public void SetScore(int _score)
    {
        score = _score;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {

            Destroy(this);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
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
