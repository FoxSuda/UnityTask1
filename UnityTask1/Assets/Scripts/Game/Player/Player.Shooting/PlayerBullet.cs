using System;
using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private int soundCategory = 0;

        private PlayerStats player;
        private PlayerWeaponBase weapon;
        private Action<PlayerBullet> OnBulletReleased;
        public void Initialize(PlayerStats player, PlayerWeaponBase weapon, Action<PlayerBullet> onBulletReleased)
        {
            this.player = player;
            this.weapon = weapon;
            OnBulletReleased = onBulletReleased;
        }

        public void Dispose()
        {
            OnBulletReleased = null;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                soundObject.GetComponent<Sound>().PlaySound(damageSound, soundCategory);
                enemy.TakeDamage(weapon.GetDamage * player.DoDamage(), player);
            }

            OnBulletReleased?.Invoke(this);
        }
    }

}
