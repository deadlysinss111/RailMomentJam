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
    CanvasScaler CanvasScalerComp;
    Vector2Int screenSize;



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
