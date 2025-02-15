using UnityEngine;
using UnityEngine.Splines;

public class SpawnBalloon : MonoBehaviour
{
    public float liftSpeed = 1f;
    public float lifetime = 8f;
    private float timer = 0f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0,1,0) /** liftSpeed*/ * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}