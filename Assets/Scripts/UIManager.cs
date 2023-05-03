using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private SaveDataChannel saveDataChannel;
    [SerializeField] private SceneReference mainMenuScene;
    [SerializeField] private LoadSceneChannel loadSceneChannel;

    [SerializeField] private SceneReference forestScene;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Save();
            loadSceneChannel.Load(mainMenuScene);
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            loadSceneChannel.Load(forestScene);
        }
    }
    private void Save()
    {
        gameData.LoadFromBinaryFile();
        saveDataChannel.Save();
        gameData.SaveToBinaryFile();
    }
}
