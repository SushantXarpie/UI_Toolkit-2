using System;
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

    [SerializeField] private SceneReadyChannel sceneReadyChannel;
    [SerializeField] private LoadingScreen loadingScreen;

    private void OnEnable()
    {
        loadSceneChannel.load += OnLoadScene;
        sceneReadyChannel.ready += OnSceneReady;
    }

    private void OnSceneReady()
    {
        loadingScreen.gameObject.SetActive(false);
    }

    private void OnLoadScene(SceneReference reference)
    {
        loadingScreen.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
            loadSceneChannel.Load(mainMenuScene);
        }
        else if (Input.GetKeyDown(KeyCode.F))
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

    private void OnDisable()
    {
        loadSceneChannel.load -= OnLoadScene;
        sceneReadyChannel.ready -= OnSceneReady;
    }
}
