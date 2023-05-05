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
    private Button settingsButton;
    private Button mainMenuButton;
    private Button quitButton;

    private SettingsElements settingsElement;
    private Button closeSettings;



    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }


    private void OnEnable()
    {
        resumeButton = root.Q<Button>("ResumeButton");
        quitButton = root.Q<Button>("CloseButton");
        settingsButton = root.Q<Button>("SettingsButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");
        settingsElement = root.Q<SettingsElements>();
        closeSettings = settingsElement.Q<Button>("Close-Button");
        resumeButton.clicked += OnResume;
        inputReader.paused += OnPause;
        inputReader.unPaused += OnResume;
        quitButton.clicked += OnResume;

        settingsButton.clicked += OnSettingsClicked;
        mainMenuButton.clicked += OnMainMenuClicked; 
        closeSettings.clicked += OnCloseSettings;
        Time.timeScale = 0;
    }

    private void OnCloseSettings()
    {
        settingsElement.style.display = DisplayStyle.None;
    }

    private void OnMainMenuClicked()
    {
        
    }

    private void OnSettingsClicked()
    {
        settingsElement.style.display = DisplayStyle.Flex;
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
