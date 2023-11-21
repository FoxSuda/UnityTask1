using Task1.Player;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private Text weaponAmmoText;
    [SerializeField] private Image primaryWeaponImage;
    [SerializeField] private Image secondaryWeaponImage;
    [SerializeField] private GameObject primaryWeapon;
    [SerializeField] private GameObject secondaryWeapon;
    public GameObject currentWeapon;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        EquipWeapon(primaryWeapon);
        SetImageAlpha(primaryWeaponImage, secondaryWeaponImage);
    }

    public void SwitchToPrimaryWeapon()
    {
        EquipWeapon(primaryWeapon);
        SetImageAlpha(primaryWeaponImage, secondaryWeaponImage);
    }

    public void SwitchToSecondaryWeapon()
    {
        EquipWeapon(secondaryWeapon);
        SetImageAlpha(secondaryWeaponImage, primaryWeaponImage);
    }

    private void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        weapon.SetActive(true);

        currentWeapon = weapon;
        playerStats.SetCurrentWeapon(weapon);
    }

    private void SetImageAlpha(Image currentWeapon, Image lastWeapon)
    {
        Color currentWeaponColor = currentWeapon.color;
        Color lastWeaponColor = lastWeapon.color;

        currentWeaponColor.a = 1f;
        lastWeaponColor.a = 0.5f;

        currentWeapon.color = currentWeaponColor;
        lastWeapon.color = lastWeaponColor;
    }
}
