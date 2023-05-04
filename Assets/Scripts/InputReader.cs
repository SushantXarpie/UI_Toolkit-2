using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, Controls.IGamePlayActions, Controls.IUIActions
{
    private Controls controls;
    public event Action paused;
    public event Action unPaused;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.GamePlay.SetCallbacks(this);
            controls.UI.SetCallbacks(this);
        }
        controls.Enable();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            paused?.Invoke();
        }
    }

    public void OnUnpause(InputAction.CallbackContext context)
    {
        if (context.performed) unPaused?.Invoke();
    }

    public void EnableUIInput()
    {
        controls.UI.Enable();
        controls.GamePlay.Disable();
    }

    public void EnableGamePlayInput()
    {
        controls.GamePlay.Enable();
        controls.UI.Disable();
    }
}
