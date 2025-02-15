using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
   [SerializeField] private GameObject objectToBeSpawned1 = null;
    [SerializeField] private GameObject objectToBeSpawned2 = null;
    private Camera cam = null;
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private float forceAmount = 600f;
    [SerializeField] PlayerManager playerManager;
    int ballcount;
    int ballToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ballcount = playerManager.GetBallCount();
        ballToSpawn = playerManager.GetBallToSpawn();

        GameObject ballToUse = null;

        if (ballToSpawn == 1)
        {
            ballToUse = objectToBeSpawned1;
        }
        else if (ballToSpawn == 2)
        {
            ballToUse = objectToBeSpawned2;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && ballcount > 0)
        {
            // 1️ Faire spawn la balle devant la caméra
            Vector3 spawnPosition = cam.transform.position + cam.transform.forward * spawnDistance;
            GameObject ball = Instantiate(ballToUse, spawnPosition, Quaternion.identity);

            // 2️ Lancer un Raycast depuis la caméra vers la position de la souris
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = ~LayerMask.GetMask("Balle");

            // 3️ Si le Raycast touche quelque chose, appliquer une force vers ce point
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();

                //Debug.Log("Hit position: " + hit.point);

                if (rb != null)
                {
                        Vector3 direction = (hit.point - spawnPosition).normalized; // Direction vers la cible

                        // 🔹 Aligner la balle avec la direction du tir
                        ball.transform.rotation = Quaternion.LookRotation(direction);

                        // 🔹 Appliquer la force dans la même direction
                        rb.AddForce(direction * forceAmount);
                    
                }
            }
            else
            {
                Debug.Log("Le Raycast n'a touché aucun objet.");

                Rigidbody rb = ball.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    //Vector3 direction = (hit.point - spawnPosition).normalized; // Direction vers la cible
                    Vector3 targetPoint = cam.transform.position + cam.transform.forward * 50f;

                    Vector3 direction = (targetPoint - spawnPosition).normalized;

                    // 🔹 Aligner la balle avec la direction du tir
                    ball.transform.rotation = Quaternion.LookRotation(direction);

                    // 🔹 Appliquer la force dans la même direction
                    rb.AddForce(direction * forceAmount);
                }
            }
            playerManager.ChangeBallCount(-1);
        }
    }
}
