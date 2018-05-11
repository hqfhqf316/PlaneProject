using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingValue : MonoBehaviour {
    //[SerializeField]
    //private AudioMixer audiomixer;
    [SerializeField]
    private Slider FXSilder;
    [SerializeField]
    private Slider MUSilder;
    

    private void Awake()
    {
        MUSilder.value = AudioManger.Instance.MusicVolume;
        FXSilder.value = AudioManger.Instance.FXVolume;
    }
    
    public void OnMusicSilder(float volume)
    {
        AudioManger.Instance.MusicVolume = volume;
    }
    public void OnFXSilder(float volume)
    {
        AudioManger.Instance.FXVolume = volume;
    }
   
    


}
