using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchproj : MonoBehaviour
{
    [SerializeField] PlayerManager mplayerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            mplayerManager.ChangeBalloonCount(2);
        }
    }
}
