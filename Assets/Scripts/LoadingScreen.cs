using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class LoadingScreen : MonoBehaviour
{
    private VisualElement root;
    private ProgressBar progressBar;
    [SerializeField] private DownloadState downloadState;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        progressBar = root.Q<ProgressBar>();
    }

    private void LateUpdate()
    {
        progressBar.value = downloadState.progress;
        
    }


}
