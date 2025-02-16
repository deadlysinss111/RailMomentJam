using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] SplineAnimate rider;
    public float speed;
    float targetSpeed;
    [NonSerialized] public float lerpFactor;

    private void Start()
    {
        targetSpeed = speed;
    }

    private void Update()
    {
        print(speed);
        rider.MaxSpeed = speed;
        if (Mathf.Abs(targetSpeed - speed) <= .5f)
        {
            speed = targetSpeed;
            return;
        }
        else
        {
            speed = Mathf.Lerp(speed, targetSpeed, lerpFactor * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<SpeedChanger>(out SpeedChanger changer))
        {
            targetSpeed = changer.speedAimed;
            lerpFactor = changer.lerpFactor;
        }
    }
}
