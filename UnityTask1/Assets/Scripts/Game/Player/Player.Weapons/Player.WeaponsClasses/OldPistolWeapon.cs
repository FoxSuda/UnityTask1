public class OldPistolWeapon : PlayerWeaponBase
{
    private void Start()
    {
        damage = 10;
        maxAmmo = 15;
        reloadTime = 1.0f;
        currentAmmo = maxAmmo;
    }
}
