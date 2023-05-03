using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[CreateAssetMenu(fileName = "GameData", menuName = "SaveSystem/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private string fileName;
    private bool isDataLoaded;
    [SerializeField, HideInInspector] private string path;
    private Dictionary<string, object> data = new Dictionary<string, object>();
    public bool hasPreviousSave => File.Exists(path);

    public void Save(ISavable<SceneData> scene)
    {
        SceneData sceneData = scene.data;
        data[nameof(sceneData)] = sceneData;
    }

    public void Load(ISavable<SceneData> scene)
    {
        if (isDataLoaded)
        {
            scene.Load((SceneData)data[nameof(scene.data)]);
        }
        else
        {
            Debug.LogWarning("Data not loaded");
        }
    }
    [ContextMenu("Delete Save")]
    public void DeleteScene()
    {
        if(hasPreviousSave)
        {
            File.Delete(path);
        }
    }

    public void LoadFromBinaryFile()
    {
        if (!isDataLoaded)
        {
            if (hasPreviousSave)
            {
                FileManager.LoadFromBinaryFile(path, out object _data);
                data = (Dictionary<string, object>)_data;
            }
            isDataLoaded = true;
        }
        else
        {
            Debug.LogWarning("Data already loaded");
        }
    }

    public void SaveToBinaryFile()
    {
        FileManager.SaveToBinaryFile(path, data);
    }

    private void OnValidate()
    {
        path = Path.Combine(Application.persistentDataPath, fileName);
    }

}
