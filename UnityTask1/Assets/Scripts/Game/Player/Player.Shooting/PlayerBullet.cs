using System;
using Task1.EnemyStats;
using Task1.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private AudioSource sound;

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
                sound.Play();
                enemy.TakeDamage(weapon.GetDamage * player.DoDamage(), player);
            }

            OnBulletReleased?.Invoke(this);
        }
    }

}
