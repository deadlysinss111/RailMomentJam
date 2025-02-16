using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rider"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
