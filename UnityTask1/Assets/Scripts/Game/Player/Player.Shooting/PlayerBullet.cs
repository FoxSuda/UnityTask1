using System;
using System.Collections;
using Task1.EnemyParticleSystem;
using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBullet : MonoBehaviour
    {
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
            StartCoroutine(Released());
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
                enemy.TakeDamage(damage, player, gameObject.transform);
                playerUIInstantiate.OnObjectHit(gameObject.transform, damage);
            }

            OnBulletReleased?.Invoke(this);
        }

        private IEnumerator Released()
        {
            yield return new WaitForSeconds(10f);

            OnBulletReleased?.Invoke(this);
        }
    }

}
