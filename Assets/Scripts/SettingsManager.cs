using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private const string currentResolutionIndexKey = "currentResolutionIndex";
    private const string FullScreenKey = "FullScreen";

    private void Awake()
    {
        Resolution resolution = Screen.resolutions[PlayerPrefs.GetInt(currentResolutionIndexKey)];
        Screen.SetResolution(resolution.width, resolution.height, Convert.ToBoolean(PlayerPrefs.GetInt(FullScreenKey)));
    }
}
 