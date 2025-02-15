using UnityEngine;
using UnityEngine.Splines;

public class Balloon : MonoBehaviour
{
    public float liftSpeed = 100f;
    public float lifetime = 5f;
    private float timer = 0f;

    void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(Vector3.up * liftSpeed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
