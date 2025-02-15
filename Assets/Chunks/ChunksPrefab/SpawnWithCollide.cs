using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithCollide : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned = null;
    [SerializeField] public PlayerManager playerManager;
    public float speed = 10f;
    private int nbBalloon = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collide detecte with {other.name}");

        if (other.gameObject.CompareTag("Rider"))
        { 
            for (int i = 0; i < nbBalloon; i++)
            {
                GameObject ball = Instantiate(objectToBeSpawned, transform.position + new Vector3(0, 7, 20), Quaternion.identity);
            }            
            Debug.Log("Spawn de balle");
            Destroy(gameObject);
        }
       
    }
}
