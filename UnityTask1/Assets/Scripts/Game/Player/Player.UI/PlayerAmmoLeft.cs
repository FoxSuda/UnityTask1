using Task1.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoLeft : MonoBehaviour
{
    [SerializeField] private Text weaponAmmoText;

    [SerializeField] private GameObject playerObject;
    private PlayerStats playerWeapon;
    private PlayerWeaponBase weaponAmmo;

    private GameObject weapon;

    private void Start()
    {
        playerWeapon = playerObject.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (playerWeapon.GetCurrentWeapon() != weapon)
        {
            weaponAmmo = playerWeapon.GetCurrentWeapon().GetComponent<PlayerWeaponBase>();
        }
        weaponAmmoText.text = "" + weaponAmmo.currentAmmo + "/" + weaponAmmo.weaponConfiguration.MaxAmmo;
    }
}
