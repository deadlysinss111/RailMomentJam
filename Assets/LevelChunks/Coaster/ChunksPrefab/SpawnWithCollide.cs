using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithCollide : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned = null;
    public float speed = 10f;
    private int nbBalloon = 10;
    public Vector3 spawnPoint = new Vector3(0, 0, 0);


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Collide detecte with {other.name}");

        nbBalloon = PlayerManager.instance.GetBalloonCount();

        if (other.gameObject.CompareTag("Rider"))
        { 
            for (int i = 0; i < nbBalloon; i++)
            {
                float radius = 2f; // Rayon autour du point
                Vector3 randomOffset = Random.insideUnitSphere * radius;

                GameObject ball = Instantiate(
                    objectToBeSpawned,
                    transform.position + spawnPoint + randomOffset,
                    Quaternion.identity
                );
            }            
            Debug.Log("Spawn de balle");
            Destroy(gameObject);
        }
       
    }
}
