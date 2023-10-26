using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerInputs playerInputActions;

    public delegate void SwitchWeaponEvent();
    public delegate void PlayerMovementEvent();

    public event SwitchWeaponEvent OnSwitchPrimaryWeapon;
    public event SwitchWeaponEvent OnSwitchSecondaryWeapon;

    private void Awake()
    {
        playerInputActions = new PlayerInputs();
        playerInputActions.PlayerInput.SwitchWeaponMain.started += SwitchWeaponMainStarted;
    }



    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void SwitchWeaponMainStarted(InputAction.CallbackContext ctx)
    {
        if (ctx.control.name == "1")
        {
            OnSwitchPrimaryWeapon?.Invoke();
        }
        else
        {
            OnSwitchSecondaryWeapon?.Invoke();
        }
    }
}
