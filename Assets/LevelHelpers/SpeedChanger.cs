using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SpeedChanger : MonoBehaviour
{
    /*
     *  FIELDS
     */
    public float speedAimed;
    public float transitionDuration;

    /*
     *  METHODS
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Changing");
        SplineAnimate animComp = GameObject.Find("Rider").GetComponent<SplineAnimate>();
    }

    /*
     *  UNITY METHODS
     */
    private void Update()
    {
        
    }
}
