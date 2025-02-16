using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /*
     *  METHODS
     */
    public void StartGame()
    {
        SceneManager.LoadScene("WIP", LoadSceneMode.Single);
        SceneManager.LoadScene("HUDScene", LoadSceneMode.Additive);
    }
    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void OpenWIP()
    {
        SceneManager.LoadScene("WIP", LoadSceneMode.Single);
    }
}
