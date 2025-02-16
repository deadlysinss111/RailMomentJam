using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    /*
     *  FIELDS
     */
    AudioSource[] audioSources;



    /*
     *  UNITY METHODS
     */
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }



    /*
     *  METHODS
     */
    public void PlayClip(int index)
    {
        audioSources[index].Play();
    }
}
