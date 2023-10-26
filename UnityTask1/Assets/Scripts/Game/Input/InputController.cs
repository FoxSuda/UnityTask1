using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerInputs playerInputActions;

    public delegate void SwitchWeaponEvent();

    public event SwitchWeaponEvent OnSwitchPrimaryWeapon;
    public event SwitchWeaponEvent OnSwitchSecondaryWeapon;

    public float moveActionsHor;
    public float moveActionsVer;

    private void Awake()
    {
        playerInputActions = new PlayerInputs();
        playerInputActions.PlayerInput.SwitchWeaponMain.started += SwitchWeaponMainStarted;
    }

    private void Update()
    {
        moveActionsHor = playerInputActions.PlayerInput.PlayerMovementHorizontal.ReadValue<float>();
        moveActionsVer = playerInputActions.PlayerInput.PlayerMovementVertical.ReadValue<float>();
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
