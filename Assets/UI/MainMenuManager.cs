using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /*
     *  METHODS
     */
    public void StartGame()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        SceneManager.LoadScene("HUDScene", LoadSceneMode.Additive);
    }
    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
    }
    public void OpenWIP()
    {
        SceneManager.LoadScene("WIP", LoadSceneMode.Single);
    }
}
