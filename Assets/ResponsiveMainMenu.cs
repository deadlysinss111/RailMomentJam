using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveMainMenu : MonoBehaviour
{
    /*
     *  FIELDS
     */
    // Canvas components
    CanvasScaler CanvasScalerComp;

    // Context data
    Vector2Int screenSize;

    // TODO: kinda remove
    // Placement parameters
    public float IMG_logoTopOffset;         // (unit: % of the screen)
    public float PAN_controlsBottomOffset;  // (unit: % of the screen)
    public float BTN_buttonTopOffset;       // (unit: % of the screen)

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
