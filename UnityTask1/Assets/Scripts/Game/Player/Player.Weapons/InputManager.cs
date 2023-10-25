using UnityEngine;

public class InputManager : MonoBehaviour
{
    private WeaponManager weaponManager;

    private void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponManager.SwitchToPrimaryWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponManager.SwitchToSecondaryWeapon();
        }
    }
}
