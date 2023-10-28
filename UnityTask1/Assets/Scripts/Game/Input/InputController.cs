using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerInputs playerInputActions;

    public delegate void SwitchWeaponEvent();
    public delegate void PlayerJumpEvent();
    public delegate void PlayerShootEvent();

    public event SwitchWeaponEvent OnSwitchPrimaryWeapon;
    public event SwitchWeaponEvent OnSwitchSecondaryWeapon;

    public event PlayerJumpEvent OnJump;

    public event PlayerShootEvent OnShoot;

    public float moveActionsHor;
    public float moveActionsVer;

    private void Awake()
    {
        playerInputActions = new PlayerInputs();
        playerInputActions.PlayerInput.SwitchWeaponMain.started += SwitchWeaponMainStarted;
        playerInputActions.PlayerInput.Jump.started += JumpStarted;
        playerInputActions.PlayerInput.Shoot.started += ShootStarted;
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
    
    private void JumpStarted(InputAction.CallbackContext ctx)
    {
        if (ctx.control.name == "space")
        {
            OnJump?.Invoke();
        }
    }
    
    private void ShootStarted(InputAction.CallbackContext ctx)
    {
        if (ctx.control.name == "leftButton")
        {
            OnShoot?.Invoke();
        }
    }
}
