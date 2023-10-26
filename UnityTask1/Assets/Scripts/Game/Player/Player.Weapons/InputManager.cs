using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputController inputController;
    private WeaponManager weaponManager;

    private void Start()
    {
        inputController = GetComponent<InputController>();
        inputController.OnSwitchPrimaryWeapon += SwitchPrimaryWeapon;
        inputController.OnSwitchSecondaryWeapon += SwitchSecondaryWeapon;
        weaponManager = GetComponent<WeaponManager>();
    }

    private void SwitchPrimaryWeapon()
    {
        weaponManager.SwitchToPrimaryWeapon();
    }

    private void SwitchSecondaryWeapon()
    {
        weaponManager.SwitchToSecondaryWeapon();
    }
}
