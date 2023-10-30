using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class DamageEnemy : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private int soundCategory = 0;

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
                soundObject.GetComponent<Sound>().PlaySound(damageSound, soundCategory);
                enemy.TakeDamage(weapon.damage * player.DoDamage(), player);
            }

            Destroy(gameObject);
        }
    }
}

