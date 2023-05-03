using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SceneReference managerScene;
    [SerializeField] private SceneReference mainMenuScene;
    [SerializeField] private AssetReferenceT<LoadSceneChannel> loadSceneChannel;

    private IEnumerator Start()
    {
        yield return managerScene.LoadSceneAsync(LoadSceneMode.Additive);
        var handel = loadSceneChannel.LoadAssetAsync<LoadSceneChannel>();
        yield return handel;
        handel.Result.Load(mainMenuScene);
        SceneManager.UnloadSceneAsync("EntryPoint");

    }
}
