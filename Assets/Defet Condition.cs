using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatCondition : MonoBehaviour
{
    public string playerTag = "Player Life";
    public string defeatSceneName = "DefeatScene";

    private GameObject playerLifeObject;

    void Start()
    {

        playerLifeObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerLifeObject == null)
        {
            Debug.LogError("Aucun objet avec le tag 'Player collision' n'a été trouvé !");
        }
    }

    void Update()
    {
        if (playerLifeObject == null)
        {
            Debug.Log("About to laod scene");
            SceneManager.LoadScene(defeatSceneName, LoadSceneMode.Single);
        }
    }
}
