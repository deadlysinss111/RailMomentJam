using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    /*
     *  FIELDS
     */
    PlayerManager PlayerManager;
    [SerializeField] TextMeshProUGUI TXT_score;
    [SerializeField] TextMeshProUGUI TXT_ammo;



    /*
     *  UNITY METHODS
     */
    private void Start()
    {
        GameObject playerManager = GameObject.Find("PlayerManager");
        if (playerManager)
            PlayerManager = playerManager.GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if (PlayerManager)
        {
            TXT_score.text = PlayerManager.Getscore().ToString();
            TXT_ammo.text = PlayerManager.ballCount.ToString();
        }
    }
}
