using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VisualSettingsElement : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VisualSettingsElement, UxmlTraits> { }

    private Label resolutionLabel;
    private Label fullscreenLabel;

    private int currentResolutionIndex;
    private bool isFullScreen;

    private const string currentResolutionIndexKey = "currentResolutionIndex";
    private const string FullScreenKey = "FullScreen";

    public VisualSettingsElement()
    {
        VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UIDocuments/VisualSettings");
        visualTree.CloneTree(this);

        resolutionLabel = this.Q<Label>("resolution-setting-value");
        fullscreenLabel = this.Q<Label>("full-screen-setting-value");

        Button perviousResolutionButton = this.Q<PlainButton>("Previous-resolution-Button");
        perviousResolutionButton.clicked += OnPreviousResolutionClicked;
        Button nextResolutionButton = this.Q<PlainButton>("Next-resolution-Button");
        nextResolutionButton.clicked += OnNextResolutionClicked;
        Button previousFullscreenButton = this.Q<PlainButton>("Previous-Full-Screen-Button");
        previousFullscreenButton.clicked += OnPreviousFullScreenClicked;
        Button nextFullscreenButton = this.Q<PlainButton>("Next-Full-Screen-Button");
        nextFullscreenButton.clicked += OnNextFullScreenClicked;

        isFullScreen = Screen.fullScreen;
        SetFullScreenField();

        if (PlayerPrefs.HasKey(currentResolutionIndexKey))
        {
            currentResolutionIndex = PlayerPrefs.GetInt(currentResolutionIndexKey);
        }

        else
        {
            currentResolutionIndex = Array.FindIndex(Screen.resolutions, resolution => resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height);
        }

        OnResolutionChanged();
    }

    public void Save()
    {
        PlayerPrefs.SetInt(currentResolutionIndexKey, currentResolutionIndex);
        PlayerPrefs.SetInt(FullScreenKey, Convert.ToInt32(isFullScreen));
    }

    public void Reset()
    {
        currentResolutionIndex = PlayerPrefs.GetInt(currentResolutionIndexKey);
        isFullScreen = Convert.ToBoolean(PlayerPrefs.GetInt(FullScreenKey));
        OnResolutionChanged();
    }

    private void OnNextFullScreenClicked()
    {
        isFullScreen = true;
        OnFullScreenChanged();
    }

    private void OnPreviousFullScreenClicked()
    {
        isFullScreen = false;
        OnFullScreenChanged();
    }

    private void OnFullScreenChanged()
    {
        Screen.fullScreen = isFullScreen;
        SetFullScreenField();
    }

    private void SetFullScreenField()
    {
        fullscreenLabel.text = isFullScreen ? "On" : "Off";
    }

    private void OnNextResolutionClicked()
    {
        currentResolutionIndex = Mathf.Clamp(currentResolutionIndex + 1, 0, Screen.resolutions.Length - 1);
        OnResolutionChanged();
    }

    private void OnPreviousResolutionClicked()
    {
        currentResolutionIndex = Mathf.Clamp(currentResolutionIndex - 1, 0, Screen.resolutions.Length - 1);
        OnResolutionChanged();
    }

    private void OnResolutionChanged()
    {
        Resolution resolution = Screen.resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);
        SetResolutionField();
    }

    private void SetResolutionField()
    {
        string displayText = Screen.resolutions[currentResolutionIndex].ToString();
        displayText = displayText.Substring(0, displayText.IndexOf('@'));
        resolutionLabel.text = displayText;
    }
}
