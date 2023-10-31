using Task1.Player;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private GameObject inputControllerObject;
        [SerializeField] private GameObject soundObject;
        private InputController inputController;

        [SerializeField] private float bulletSpeed = 10f;

        [SerializeField] private Transform firePoint;

        private void Start()
        {
            inputController = inputControllerObject.GetComponent<InputController>();
            inputController.OnShoot += Shoot;
        }

        private void Shoot()
        {
            GameObject currentWeapon = playerStats.GetCurrentWeapon();
            PlayerWeaponBase shootWeapon = currentWeapon.GetComponent<PlayerWeaponBase>();

            bool isShooting = shootWeapon.Shoot();

            if (isShooting)
            {
                GameObject bullet = ShootingObjectPool.bulletSharedInstance.GetBulletPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);

                    DamageEnemy playerBullet = bullet.GetComponent<DamageEnemy>();
                    playerBullet.DoDamageToEnemy(playerStats, shootWeapon);
                    playerBullet.soundObject = soundObject;

                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * bulletSpeed;
                }
            }
            else
            {
                shootWeapon.Reload();
            }
        }
    }
}

