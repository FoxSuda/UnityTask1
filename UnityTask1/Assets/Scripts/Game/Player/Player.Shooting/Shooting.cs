using Task1.Player;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float bulletLifetime = 10f;

        [SerializeField] private Transform bulletParent;
        [SerializeField] private Transform firePoint;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject currentWeapon = playerStats.GetCurrentWeapon();
                PlayerWeaponBase shootWeapon = currentWeapon.GetComponent<PlayerWeaponBase>();

                bool isShooting = shootWeapon.Shoot();

                if (isShooting)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation, bulletParent);

                    DamageEnemy player = bullet.GetComponent<DamageEnemy>();
                    player.DoDamageToEnemy(playerStats, shootWeapon);

                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * bulletSpeed;

                    Destroy(bullet, bulletLifetime);
                } else
                {
                    shootWeapon.Reload();
                }
            }
        }
    }
}

