using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LoadDataChannel", menuName = "Channels/LoadDataChannel")]
public class LoadDataChannel : ScriptableObject
{
    public event Action load;

    public void Load()
    {
        load?.Invoke();
    }
}
