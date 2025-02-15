using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballHealth = 50f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Life lifeScript = collision.gameObject.GetComponent<Life>();

            if (lifeScript != null)
            {
                lifeScript.TakeDamage(ballHealth);
            }
        }
    }
}
