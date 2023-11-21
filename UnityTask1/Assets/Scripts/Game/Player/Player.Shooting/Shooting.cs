using Task1.Player;
using Task1.Pool;
using UnityEngine;

namespace Task1.Player
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerUIInstantiate playerUIInstantiate;

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
                    pooledBullet.Initialize(playerStats, shootWeapon, ReleaseBullet, playerUIInstantiate);
                    pooledBullet.soundObject = soundObject;

                    Rigidbody rb = pooledBullet.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * bulletSpeed;
                }
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

