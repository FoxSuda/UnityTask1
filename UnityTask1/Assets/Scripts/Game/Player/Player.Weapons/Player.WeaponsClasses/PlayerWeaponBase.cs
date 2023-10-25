using System.Collections;
using UnityEngine;

public class PlayerWeaponBase : MonoBehaviour
{
    public int damage = 10;
    public int maxAmmo = 30;
    public float reloadTime = 2.0f;

    public int currentAmmo;
    private bool isReloading = false;

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
            return true;
        }
        return false;
    }

    public void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            isReloading = true;
            StartCoroutine(EndReload());
        }
    }

    private IEnumerator EndReload()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}




