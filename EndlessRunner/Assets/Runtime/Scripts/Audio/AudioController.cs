using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    private float minValue = -60;
    private float maxValue = 0;

    private const string MasterVolumeParameter = "MasterVolume";
    private const string MusicVolumeParameter = "MusicVolume";
    private const string SFXVolumeParameter = "SFXVolume";


    public float MasterVolume
    {
        get => GetMixerVolumeParameter(MasterVolumeParameter);
        set => SetMixerVolumeParameter(MasterVolumeParameter, value);
    }

    public float MusicVolume
    {
        get => GetMixerVolumeParameter(MusicVolumeParameter);
        set => SetMixerVolumeParameter(MusicVolumeParameter, value);
    }

    public float SFXVlume
    {
        get => GetMixerVolumeParameter(SFXVolumeParameter);
        set => SetMixerVolumeParameter(SFXVolumeParameter, value);
    }

    /*private void Start()
    {
        LoadAudioPreferences();
    }

    private void LoadAudioPreferences()
    {
        gameSaver.LoadGame();
        MainVolume = gameSaver.AudioPreferences.MainVolume;
        MusicVolume = gameSaver.AudioPreferences.MusicVolume;
        SFXVolume = gameSaver.AudioPreferences.SFXVolume;
    }*/



    private void SetMixerVolumeParameter(string key, float volumePercent)
    {
        var volume = Mathf.Lerp(minValue, maxValue, volumePercent);
        audioMixer.SetFloat(key, volume);
    }

    private float GetMixerVolumeParameter(string key)
    {
        if(audioMixer.GetFloat(key, out var value))
        {
            return Mathf.InverseLerp(minValue, maxValue, value);
        }
        return 1;
    }

}
