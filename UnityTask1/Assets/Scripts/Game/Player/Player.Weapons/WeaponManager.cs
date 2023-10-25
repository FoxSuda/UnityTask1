using Task1.Player;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private GameObject primaryWeapon;
    [SerializeField] private GameObject secondaryWeapon;
    public GameObject currentWeapon;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        EquipWeapon(primaryWeapon);
    }

    public void SwitchToPrimaryWeapon()
    {
        EquipWeapon(primaryWeapon);
    }

    public void SwitchToSecondaryWeapon()
    {
        EquipWeapon(secondaryWeapon);
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
}
