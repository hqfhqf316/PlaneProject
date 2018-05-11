using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManger :ContinuousSingleTon<AudioManger> {
    [SerializeField]
    private AudioMixer audiomixer;
    private float fxvolume;
    private float muvolume;
    protected override void Awake()
    {
        base.Awake();
        print("ssss");
        muvolume = -80;
        fxvolume = -80;
        audiomixer.SetFloat("BackMusicVolume", muvolume);
        audiomixer.SetFloat("FXVolume", fxvolume);
    }
    private void Update()
    {
        
    }
    public float MusicVolume {
        get { return muvolume; }
        set {
            muvolume = value;
            audiomixer.SetFloat("BackMusicVolume", value);
        }
    }
    public float FXVolume
    {
        get { return fxvolume; }
        set
        {
            fxvolume = value;
            audiomixer.SetFloat("FXVolume", value);
        }
    }
}
