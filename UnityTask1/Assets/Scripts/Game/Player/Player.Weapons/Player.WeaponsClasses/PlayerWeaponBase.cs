using System.Collections;
using UnityEngine;

public class PlayerWeaponBase : MonoBehaviour
{
    public WeaponConfiguration weaponConfiguration;

    public delegate void AmmoChangedDelegate();
    public event AmmoChangedDelegate OnAmmoChanged;

    public int currentAmmo;
    private bool isReloading = false;

    private void Awake()
    {
        currentAmmo = weaponConfiguration.MaxAmmo;
    }

    private void OnEnable()
    {
        if (currentAmmo <= 0)
        {
            isReloading = true;
            StartCoroutine(EndReload());
        }
    }

    public float GetDamage
    {
        get { return weaponConfiguration.Damage; }
    }

    public int CurrentAmmo
    {
        get { return currentAmmo; }
    }

    public bool IsReloading
    {
        get { return isReloading; }
    }

    public bool Shoot()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            currentAmmo--;
            OnAmmoChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void Reload()
    {
        if (currentAmmo < weaponConfiguration.MaxAmmo && !isReloading)
        {
            isReloading = true;
            StartCoroutine(EndReload());
        }
    }

    private IEnumerator EndReload()
    {
        yield return new WaitForSeconds(weaponConfiguration.ReloadTime);
        currentAmmo = weaponConfiguration.MaxAmmo;
        OnAmmoChanged?.Invoke();
        isReloading = false;
    }
}




