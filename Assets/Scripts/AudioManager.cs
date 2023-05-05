using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private const string masterVolumeKey = "MasterVolume";
    private const string musicVolumeKey = "MusicVolume";
    private const string sfxVolumeKey = "SFXVolume";

    private void Awake()
    {
        audioMixer.SetFloat(masterVolumeKey, Mathf.Log10(PlayerPrefs.GetFloat(masterVolumeKey, 1f)) * 20);
        audioMixer.SetFloat(musicVolumeKey, Mathf.Log10(PlayerPrefs.GetFloat(musicVolumeKey, 1f)) * 20);
        audioMixer.SetFloat(sfxVolumeKey, Mathf.Log10(PlayerPrefs.GetFloat(sfxVolumeKey, 1f)) * 20);
    }
}
