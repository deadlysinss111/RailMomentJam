﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
   [SerializeField] private GameObject objectToBeSpawned = null;
    private Camera cam = null;
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private float forceAmount = 500f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // 1️⃣ Faire spawn la balle devant la caméra
            Vector3 spawnPosition = cam.transform.position + cam.transform.forward * spawnDistance;
            GameObject ball = Instantiate(objectToBeSpawned, spawnPosition, Quaternion.identity);

            // 2️⃣ Lancer un Raycast depuis la caméra vers la position de la souris
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = ~LayerMask.GetMask("Balle");

            // 3️⃣ Si le Raycast touche quelque chose, appliquer une force vers ce point
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                //Debug.Log("Mouse hit at: " + hit.point);
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
                //Debug.Log("Le Raycast n'a touché aucun objet.");
            }
        }
    }
}
