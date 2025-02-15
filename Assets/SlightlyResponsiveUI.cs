using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlightlyResponsiveUI : MonoBehaviour
{
    /*
     *  FIELDS
     */
    // Canvas components
    CanvasScaler CanvasScalerComp;

    // Context data
    Vector2Int screenSize;



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



    /*
     *  UNITY METHODS
     */
    void Awake()
    {
        CanvasScalerComp = GetComponent<CanvasScaler>();

        screenSize.x = Screen.width;
        screenSize.y = Screen.height;
    }

    void Start()
    {
        // Applies the current screen size to the Scalar
        CanvasScalerComp.referenceResolution = screenSize;
    }
}
