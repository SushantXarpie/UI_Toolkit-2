using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuUI : MonoBehaviour
{
    private VisualElement root;

    private PlainButton continueButton;
    private PlainButton newGameButton;
    private PlainButton settingsButton;
    private PlainButton creditsButton;
    private PlainButton quitButton;

    private VisualElement confirmationScreen;
    private Button confirmButton;
    private Button cancelButton;
    private Button closeButton;

    [SerializeField] private LoadSceneChannel loadSceneChannel;
    [SerializeField] private SceneReference startingLoadScene;
    [SerializeField] private GameData gameData;
    [SerializeField] private LoadDataChannel loadDataChannel;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        continueButton = root.Q<PlainButton>("continueButton");
        newGameButton = root.Q<PlainButton>("newGameButton");
        settingsButton = root.Q<PlainButton>("settingsButton");
        creditsButton = root.Q<PlainButton>("creditsButton");
        quitButton = root.Q<PlainButton>("quitButton");
        confirmationScreen = root.Q<VisualElement>("ConfirmationModel");
        confirmButton = confirmationScreen.Q<Button>("ConfirmButton");
        cancelButton = confirmationScreen.Q<Button>("CancelButton");
        closeButton = confirmationScreen.Q<Button>("CloseButton");
        confirmationScreen.style.display = DisplayStyle.None;

        continueButton.SetEnabled(gameData.hasPreviousSave);
        continueButton.clicked += OnContinueClicked;
        quitButton.clicked += ShowConfirmationScreen;
        confirmButton.clicked += QuitGame;
        cancelButton.clicked += HideConfirmationScreen;
        closeButton.clicked += HideConfirmationScreen;

        newGameButton.clicked += StartNewGame;
    }

    private void OnContinueClicked()
    {
        gameData.LoadFromBinaryFile();
        loadDataChannel.Load();
    }

    private void StartNewGame()
    {
        loadSceneChannel.Load(startingLoadScene);
    }

    private void ShowConfirmationScreen()
    {
        confirmationScreen.style.display = DisplayStyle.Flex;
    }

    private void HideConfirmationScreen()
    {
        confirmationScreen.style.display = DisplayStyle.None;
    }

    private void QuitGame()
    {
        HideConfirmationScreen();
        Application.Quit();
    }
}
