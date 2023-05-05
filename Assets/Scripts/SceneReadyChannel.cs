using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(fileName = "SceneReadyChannel", menuName = "Channels/SceneReadyChannel")]
public class SceneReadyChannel : ScriptableObject
{
    public event Action ready;

    public void Ready()
    {
        ready?.Invoke();
    }
}
