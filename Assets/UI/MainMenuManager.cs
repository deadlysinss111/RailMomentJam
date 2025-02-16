using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /*
     *  DEBUG
     */
    public TextMeshProUGUI DEBUGscreenSize;
    private void Start()
    {
        Vector2Int screenSize = new Vector2Int();
        screenSize.x = UnityEngine.Screen.width;
        screenSize.y = UnityEngine.Screen.height;

        DEBUGscreenSize.text = screenSize.ToString();
    }




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
