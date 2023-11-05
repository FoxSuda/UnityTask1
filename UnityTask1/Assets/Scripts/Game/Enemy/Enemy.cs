using System;
using System.Collections;
using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

namespace Task1.Enemy
{
    public class Enemy : EnemyBase
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private int soundCategory = 0;

        private bool isAttacking = false;
        private float attackInterval = 1.0f;
        private float attackTimer = 0;

        
        public void Initialize(Vector3 enemyPosition, Action<EnemyBase> onEnemyReleased)
        {
            transform.position = enemyPosition;
            OnEnemyReleased = onEnemyReleased;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerBaseStats player))
            {
                isAttacking = true;
                if (Time.time - attackTimer >= attackInterval)
                {
                    StartCoroutine(AttackPeriodically(player, this));
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerBaseStats player))
            {
                isAttacking = false;
            }
        }

        private IEnumerator AttackPeriodically(PlayerBaseStats player, EnemyBase enemy)
        {
            while (isAttacking)
            {
                soundObject.GetComponent<Sound>().PlaySound(damageSound, soundCategory);
                player.TakeDamage(enemy.DoDamage());
                attackTimer = Time.time;
                yield return new WaitForSeconds(attackInterval);
            }
        }
    }
}