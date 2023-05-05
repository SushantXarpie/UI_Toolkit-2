using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioSettingsElement : VisualElement
{
    public new class UxmlFactory : UxmlFactory<AudioSettingsElement, UxmlTraits> { }

    private Slider masterVolumeSlider;
    private Slider musicVolumeSlider;
    private Slider sfxVolumeSlider;

    private const string masterVolumeKey = "MasterVolume";
    private const string musicVolumeKey = "MusicVolume";
    private const string sfxVolumeKey = "SFXVolume";

    public AudioSettingsElement()
    {
        VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UIDocuments/AudioSettings");
        visualTree.CloneTree(this);

        masterVolumeSlider = this.Q<Slider>("master-vol-slider");
        musicVolumeSlider = this.Q<Slider>("music-vol-slider");
        sfxVolumeSlider = this.Q<Slider>("sfx-vol-slider");

        AudioMixer audioMixer = Resources.Load<AudioMixer>("Audio/Main");

        masterVolumeSlider.value = PlayerPrefs.GetFloat(masterVolumeKey, 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(musicVolumeKey, 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(sfxVolumeKey, 1f);

        masterVolumeSlider.RegisterValueChangedCallback((evt) => audioMixer.SetFloat(masterVolumeKey, Mathf.Log10(evt.newValue) * 20));
        musicVolumeSlider.RegisterValueChangedCallback((evt) => audioMixer.SetFloat(musicVolumeKey, Mathf.Log10(evt.newValue) * 20));
        sfxVolumeSlider.RegisterValueChangedCallback((evt) => audioMixer.SetFloat(sfxVolumeKey, Mathf.Log10(evt.newValue) * 20));

    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat(masterVolumeKey, masterVolumeSlider.value);
        PlayerPrefs.SetFloat(musicVolumeKey, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(sfxVolumeKey, sfxVolumeSlider.value);
    }

    public void ResetAudioSettings()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat(masterVolumeKey);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(musicVolumeKey);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(sfxVolumeKey);
    }
}
