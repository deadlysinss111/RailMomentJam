using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCamera : MonoBehaviour
{
    public float posX, posY = 1, posZ;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(posX, posY, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
