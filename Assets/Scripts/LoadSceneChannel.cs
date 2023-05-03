using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LoadSceneChannel", menuName = "Channels/LoadSceneChannel")]
public class LoadSceneChannel : ScriptableObject
{
    public event Action<SceneReference> load;

    public void Load(SceneReference scene)
    {
        load?.Invoke(scene);
    }
}
