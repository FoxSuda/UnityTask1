using Task1.Player;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private PlayerWeaponBase playerWeaponBase;
    private GameObject playerCurrentWeapon;

    [SerializeField] private PlayerAmmoDisplay playerAmmoDisplay;
    [SerializeField] private HealthCountDisplay healthCountDisplay;

    private void Awake()
    {
        playerStats.OnWeaponChanged += PlayerWeaponChanged;
        playerStats.OnWeaponChanged += PlayerAmmoChanged;
        playerStats.OnHealthChanged += PlayerHealthChanged;
        PlayerHealthChanged();
    }

    private void PlayerWeaponChanged()
    {
        playerCurrentWeapon = playerStats.GetCurrentWeapon();
        playerWeaponBase = playerCurrentWeapon.GetComponent<PlayerWeaponBase>();
        playerWeaponBase.OnAmmoChanged += PlayerAmmoChanged;
    }

    private void PlayerAmmoChanged()
    {
        playerAmmoDisplay.DisplayAmmo(playerWeaponBase.currentAmmo, playerWeaponBase.weaponConfiguration.MaxAmmo);
    }
    
    private void PlayerHealthChanged()
    {
        healthCountDisplay.DisplayHealth(playerStats.GetHealthLevel());
    }
}
