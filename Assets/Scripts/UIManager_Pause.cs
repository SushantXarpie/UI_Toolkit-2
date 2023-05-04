using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UIManager_Pause : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private VisualElement root;
    private Button resumeButton;


    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }


    private void OnEnable()
    {
        resumeButton = root.Q<Button>("ResumeButton");
        resumeButton.clicked += OnResume;
        inputReader.paused += OnPause;
        inputReader.unPaused += OnResume;

        Time.timeScale = 0;
    }

    private void OnPause()
    {
        root.style.display = DisplayStyle.Flex;
        inputReader.EnableUIInput();
        Debug.Log("Paused");
    }

    private void OnResume()
    {
        root.style.display = DisplayStyle.None;
        inputReader.EnableGamePlayInput();
        Debug.Log("Resumed");
    }

    private void OnDisable()
    {
        inputReader.paused -= OnPause;
        inputReader.unPaused -= OnResume;
        Time.timeScale = 1;
    }
}
