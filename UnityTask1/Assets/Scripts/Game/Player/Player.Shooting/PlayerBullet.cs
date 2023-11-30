using System;
using System.Collections;
using Task1.EnemyParticleSystem;
using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        private GameObject soundPrefab;
        private Transform soundPrefabParent;

        private PlaySoundBullet soundBullet;
        private PlayerUIInstantiate playerUIInstantiate;
        private PlayerStats player;
        private PlayerWeaponBase weapon;
        private Action<PlayerBullet> OnBulletReleased;
        public void Initialize(PlayerStats player, PlayerWeaponBase weapon, Action<PlayerBullet> onBulletReleased, PlayerUIInstantiate playerUIInstantiate, GameObject soundObj, Transform parentObj)
        {
            soundBullet = gameObject.GetComponent<PlaySoundBullet>();
            this.player = player;
            this.weapon = weapon;
            this.playerUIInstantiate = playerUIInstantiate;
            soundPrefab = soundObj;
            soundPrefabParent = parentObj;
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
                soundBullet.PlaySoundHitBullet(soundPrefab, soundPrefabParent);
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
