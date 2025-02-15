using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnDestroy : MonoBehaviour
{
    public string targetSceneName = "DefeatScene";

    void OnDestroy()
    {
        if (gameObject.CompareTag("player Life"))
        {
            Debug.Log("L'objet avec le tag 'Player Life' a �t� d�truit.");
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
