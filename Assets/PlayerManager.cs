using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    int score = 0;
    float progress = 0;
    int ballCount = 0;
    [SerializeField] private GameObject ball = null;


    public virtual float progressUpdate()
    {
        progress += Time.deltaTime;
        return progress;
    }
    //public virtual float progressUpdate(SceneGame _scene)
    //{
    //    progress += Time.deltaTime;
    //    return 100 * progress / _scene.Gametime;
    //}
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
