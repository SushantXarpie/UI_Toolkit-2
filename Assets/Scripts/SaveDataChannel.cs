using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SaveDataChannel", menuName = "Channels/SaveDataChannel")]
public class SaveDataChannel : ScriptableObject
{
    public event Action save;

    public void Save()
    {
        save?.Invoke();
    }
}
