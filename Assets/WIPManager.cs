using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIPManager : MonoBehaviour
{
    /*
     *  METHODS
     */
    public void CloseWIP()
    {
        SceneManager.UnloadSceneAsync("WIP");
    }
}
