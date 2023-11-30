using System;
using Task1.EnemyParticleSystem;
using Task1.Player;
using UnityEngine;

namespace Task1.EnemyStats
{
    public class EnemyBase : MonoBehaviour
    {
        [HideInInspector] public GameObject soundObject;
        [SerializeField] private EnemyConfiguration enemyConfiguration;
        [SerializeField] private float _health;
        [SerializeField] private EnemyBaseAttack _enemyAttack;
        private BloodParticleInstantiate bloodParticleInstantiate;
        protected Action<EnemyBase> OnEnemyReleased;
        
        public void Initialize(Vector3 enemyPosition, Action<EnemyBase> onEnemyReleased, BloodParticleInstantiate bloodParticle)
        {
            bloodParticleInstantiate = bloodParticle;
            transform.position = enemyPosition;
            OnEnemyReleased = onEnemyReleased;
        }

        private void Awake()
        {
            _health = enemyConfiguration.Health;
        }
        
        private void OnEnable()
        {
            _health = enemyConfiguration.Health;
        }
        public void Dispose()
        {
            OnEnemyReleased = null;
        }

        public float GetMovementSpeed()
        {
            return enemyConfiguration.MoveSpeed;
        }

        public float GetHealthLevel()
        {
            return enemyConfiguration.Health;
        }

        public float DoDamage()
        {
            return enemyConfiguration.Damage;
        }

        public void TakeDamage(float damageAmount, PlayerStats player, Transform obj)
        {
            _health -= damageAmount;
            bloodParticleInstantiate.BloodInstantiate(gameObject.transform, obj);
            if (_health <= 0)
            {
                player.AddScore(enemyConfiguration.ScoreForEnemy);
               OnEnemyReleased?.Invoke(this);
            }
        }
    }
}
