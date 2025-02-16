using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] static public PlayerManager instance;
    int score = 0;
    int coins = 0;
    int gems = 0;
    float progress = 0;
    public int ballCount = 10;
    public int balloonCount = 1;
    int ballToSpawn = 1;
    [SerializeField] private GameObject ball = null;

    public int GetBalloonCount()
    {
        return balloonCount;
    } 

    public void ChangeBalloonCount(int nb)
    {
        balloonCount += nb;

        if (balloonCount < 1)
            balloonCount = 1;
    }
    public int Getscore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetGems()
    {
        return gems;
    }

    public void UpCoins(int _coins)
    {
        coins += _coins;
    }

    public void UpGems(int _gems)
    {
        gems += _gems;
    }

    public bool IsEnougthAmount(int amount)
    {
        if(coins >= amount)
        {
            RemoveCoins(amount);
            return true;
        }
        else
        {
            //Debug.log("Not enougth coins");
            return false;
        }
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
    }

    public void upScore()
    {
        score++;
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
        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ballToSpawn = 1;
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
    public void ChangeBallToSpawn(int value)
    {
        ballToSpawn = value;
    }
}
