using Task1.EnemyStats;
using Task1.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class DamageEnemy : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private AudioSource sound;
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
                sound.Play();
                enemy.TakeDamage(weapon.GetDamage * player.DoDamage(), player);
            }

            gameObject.SetActive(false);
        }
    }
}

