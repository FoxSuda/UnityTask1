using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class DamageEnemy : MonoBehaviour
    {

        private PlayerStats player;
        private PlayerWeaponBase weapon;

        public void DoDamageToEnemy(PlayerStats player, PlayerWeaponBase weapon)
        {
            this.player = player;
            this.weapon = weapon;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                enemy.TakeDamage(weapon.damage, player);
            }

            Destroy(gameObject);
        }
    }
}

