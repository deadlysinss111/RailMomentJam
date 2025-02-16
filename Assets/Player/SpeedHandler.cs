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
    [NonSerialized] public float oldSpeed;
    int sign;

    private void Start()
    {
        targetSpeed = speed;
        oldSpeed = speed;
    }

    private void Update()
    {
        rider.MaxSpeed = speed;
        if ((targetSpeed - speed)*sign <= .5f)
        {
            speed = targetSpeed;
            return;
        }
        else
        {
            speed += Mathf.Lerp(0, targetSpeed - oldSpeed, (1/ lerpFactor) * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<SpeedChanger>(out SpeedChanger changer))
        {
            targetSpeed = changer.speedAimed;
            lerpFactor = changer.lerpFactor;
            oldSpeed = speed;
            sign = (oldSpeed - targetSpeed <= 0) ? 1 : -1;
        }
    }
}
