using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, ISavable<SceneData>
{
    [SerializeField] private LoadSceneChannel loadSceneChannel;
    [SerializeField] private GameData gameData;
    [SerializeField] private SaveDataChannel saveDataChannel;
    [SerializeField] private LoadDataChannel loadDataChannel;
    [SerializeField] private SceneReadyChannel sceneReadyChannel;
    [SerializeField] private DownloadState downloadState;

    private SceneReference sceneToLoad;
    private SceneReference currentScene;

    public SceneData data => new SceneData
    {
        id = currentScene.AssetGUID
    };

    private void OnEnable()
    {
        loadSceneChannel.load += onLoadScene;
        saveDataChannel.save += onSaveData;
        loadDataChannel.load += onLoadData;
    }

    private void onLoadData()
    {
        gameData.Load(this);
    }

    private void onSaveData()
    {
        gameData.Save(this);
    }

    private void onLoadScene(SceneReference sceneReference)
    {
        sceneToLoad = sceneReference;

        if (currentScene != null)
        {
            currentScene.UnLoadScene();
        }

        StartCoroutine(LoadScene(sceneReference));
    }

    private IEnumerator LoadScene(SceneReference sceneReference)
    {
        AsyncOperationHandle<SceneInstance> handle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
        handle.Completed += OnSceneLoaded;
        while (!handle.IsDone)
        {
            var status = handle.GetDownloadStatus();
            downloadState.progress = status.Percent;
            yield return null;
        }

    }

    private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
    {
        Scene scene = handle.Result.Scene;
        SceneManager.SetActiveScene(scene);
        currentScene = sceneToLoad;
        sceneReadyChannel.Ready();
    }

    private void OnDisable()
    {
        loadSceneChannel.load -= onLoadScene;
        saveDataChannel.save -= onSaveData;
        loadDataChannel.load -= onLoadData;
    }

    public void Load(SceneData sceneData)
    {
        onLoadScene(new SceneReference(sceneData.id));
    }
}
