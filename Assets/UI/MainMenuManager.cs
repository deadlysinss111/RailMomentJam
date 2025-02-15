using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /*
     *  METHODS
     */
    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
    }
    public void OpenWIP()
    {
        SceneManager.LoadScene("WIP", LoadSceneMode.Additive);
    }
}
