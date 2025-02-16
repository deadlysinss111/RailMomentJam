using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    /*
     *  FIELDS
     */
    private AudioPlayer camAudioPlayer;

    [SerializeField] AudioMixer AudioMixer;

    [SerializeField] Slider GlobalVolumeSlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;



    /*
     *  METHODS
     */
    public void UpdateGlobalVolume()
    {
        AudioMixer.SetFloat("GlobalVolume", Mathf.Log10(GlobalVolumeSlider.value) * 20f);
    }
    public void UpdateMusicVolume()
    {
        AudioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicVolumeSlider.value) * 20f);
    }
    public void UpdateSFXVolume()
    {
        AudioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXVolumeSlider.value) * 20f);
    }

    public void CloseSettingsMenu()
    {
        //Debug.LogWarning("func CloseSettingsMenu: NOT IMPLEMENTED !");
        SceneManager.UnloadSceneAsync("SettingsMenu");
    }

    public void PlayClip(int index)
    {
        camAudioPlayer.PlayClip(index);
    }



    /*
     *  UNITY METHODS
     */
    void Start()
    {
        camAudioPlayer = GameObject.Find("Main Camera").GetComponent<AudioPlayer>();
    }
}
