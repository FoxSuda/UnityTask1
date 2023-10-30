using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerInputs playerInputActions;

    public delegate void SwitchWeaponEvent();
    public delegate void PlayerJumpEvent();
    public delegate void PlayerShootEvent();
    public delegate void PlayerGameMenuEvent();

    public event SwitchWeaponEvent OnSwitchPrimaryWeapon;
    public event SwitchWeaponEvent OnSwitchSecondaryWeapon;

    public event PlayerJumpEvent OnJump;

    public event PlayerShootEvent OnShoot;

    public event PlayerGameMenuEvent OnOpenCloseGameMenu;

    public float moveActionsHor;
    public float moveActionsVer;

    private void Awake()
    {
        playerInputActions = new PlayerInputs();
        playerInputActions.PlayerInput.SwitchWeaponMain.started += SwitchWeaponMainStarted;
        playerInputActions.PlayerInput.Jump.started += JumpStarted;
        playerInputActions.PlayerInput.Shoot.started += ShootStarted;
        playerInputActions.PlayerInput.GameMenu.started += OpenGameMenuStarted;
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
        if (ctx.control.name == "1" && Time.timeScale != 0f)
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
        if (Time.timeScale != 0f)
        {
            OnJump?.Invoke();
        }
    }
    
    private void ShootStarted(InputAction.CallbackContext ctx)
    {
        if (Time.timeScale != 0f)
        {
            OnShoot?.Invoke();
        }
    }
    
    private void OpenGameMenuStarted(InputAction.CallbackContext ctx)
    {
        OnOpenCloseGameMenu?.Invoke();
    }
}
