using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(fileName = "DownloadState", menuName = "Channels/DownloadState")]
public class DownloadState : ScriptableObject
{
    [HideInInspector, SerializeField] public float progress;
}