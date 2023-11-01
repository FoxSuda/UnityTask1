using Task1.Player;
using Task1.Pool;
using UnityEngine;

namespace Task1.Player
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private GameObject inputControllerObject;
        [SerializeField] private GameObject soundObject;
        private InputController inputController;

        [SerializeField] private float bulletSpeed = 10f;

        [SerializeField] private Transform firePoint;
        [SerializeField] private BulletObjectPool _bulletObjectPool;
        

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
                var pooledBullet = _bulletObjectPool.Pool.Get();
                if (pooledBullet != null)
                {
                    pooledBullet.transform.position = firePoint.position;
                    pooledBullet.transform.rotation = transform.rotation;
                    pooledBullet.Initialize(playerStats, shootWeapon, ReleaseBullet);
                    pooledBullet.soundObject = soundObject;

                    Rigidbody rb = pooledBullet.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * bulletSpeed;
                }
                // GameObject bullet = ShootingObjectPool.bulletSharedInstance.GetBulletPooledObject();
                // if (bullet != null)
                // {
                //     bullet.transform.position = firePoint.position;
                //     bullet.transform.rotation = transform.rotation;
                //     bullet.SetActive(true);
                //
                //     DamageEnemy playerBullet = bullet.GetComponent<DamageEnemy>();
                //     playerBullet.DoDamageToEnemy(playerStats, shootWeapon);
                //     playerBullet.soundObject = soundObject;
                //
                //     Rigidbody rb = bullet.GetComponent<Rigidbody>();
                //     rb.velocity = transform.forward * bulletSpeed;
                // }
            }
            else
            {
                shootWeapon.Reload();
            }
        }

        private void ReleaseBullet(PlayerBullet bullet)
        {
            _bulletObjectPool.Pool.Release(bullet);
        }
    }
}

