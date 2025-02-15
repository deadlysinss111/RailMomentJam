using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithCollide : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned = null;
    public float speed = 10f;

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
            GameObject ball = Instantiate(objectToBeSpawned, transform.position, Quaternion.identity);
            Debug.Log("Spawn de balle");
            Destroy(gameObject);
        }
       
    }
}
