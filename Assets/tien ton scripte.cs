using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tientonscripte : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            print("Enter");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            Destroy(this.gameObject);
            print("Stay");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
           
        }
    }   
}

