using System;
using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private AudioSource sound;

        private PlayerUIInstantiate playerUIInstantiate;
        private PlayerStats player;
        private PlayerWeaponBase weapon;
        private Action<PlayerBullet> OnBulletReleased;
        public void Initialize(PlayerStats player, PlayerWeaponBase weapon, Action<PlayerBullet> onBulletReleased, PlayerUIInstantiate playerUIInstantiate)
        {
            this.player = player;
            this.weapon = weapon;
            this.playerUIInstantiate = playerUIInstantiate;
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
                float damage = weapon.GetDamage * player.DoDamage();
                sound.Play();
                enemy.TakeDamage(damage, player);
                playerUIInstantiate.OnObjectHit(gameObject.transform, damage);
            }

            OnBulletReleased?.Invoke(this);
        }
    }

}
