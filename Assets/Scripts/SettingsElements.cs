using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsElements : VisualElement
{
    private AudioSettingsElement audioSettings;
    private VisualSettingsElement visualSettings;
    private Button graphicsButton;
    private Button audioButton;

    public new class UxmlFactory : UxmlFactory<SettingsElements, UxmlTraits> { }

    public SettingsElements()
    {
        VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UIDocuments/Settings");
        visualTree.CloneTree(this);

        visualSettings = this.Q<VisualSettingsElement>();
        audioSettings = this.Q<AudioSettingsElement>();

        visualSettings.style.display = DisplayStyle.None;
        audioSettings.style.display = DisplayStyle.None;

        Button saveButton = this.Q<Button>("SaveButton");
        Button resetButton = this.Q<Button>("ResetButton");

        graphicsButton = this.Q<Button>("graphics-tab");
        audioButton = this.Q<Button>("audio-tab");

        graphicsButton.clicked += OnGraphicsTabClicked;
        audioButton.clicked += OnAudioButtonClicked;
        saveButton.clicked += Save;
        resetButton.clicked += Reset;
    }

    private void OnAudioButtonClicked()
    {
        audioSettings.style.display = DisplayStyle.Flex;
        visualSettings.style.display = DisplayStyle.None;
        graphicsButton.SetEnabled(true);
        audioButton.SetEnabled(false);
    }

    private void OnGraphicsTabClicked()
    {
        visualSettings.style.display = DisplayStyle.Flex;
        audioSettings.style.display = DisplayStyle.None;
        graphicsButton.SetEnabled(true);
        audioButton.SetEnabled(false);
    }

    private void Save()
    {
        audioSettings.SaveAudioSettings();
        visualSettings.Save();
    }

    private void Reset()
    {
        audioSettings.ResetAudioSettings();
        visualSettings.Reset();
    }
}