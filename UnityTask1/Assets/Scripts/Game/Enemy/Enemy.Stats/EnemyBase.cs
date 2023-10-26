using Task1.Player;
using UnityEngine;

namespace Task1.EnemyStats
{
    public class EnemyBase : MonoBehaviour
    {
        public EnemyConfiguration enemyConfiguration;

        private float _health;

        private void Awake()
        {
            _health = enemyConfiguration.health;
        }

        public float GetMovementSpeed()
        {
            return enemyConfiguration.moveSpeed;
        }

        public float GetHealthLevel()
        {
            return enemyConfiguration.health;
        }

        public float DoDamage()
        {
            return enemyConfiguration.damage;
        }

        public void TakeDamage(float damageAmount, PlayerStats player)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                player.AddScore(enemyConfiguration.scoreForEnemy);
                Destroy(gameObject);
            }
        }
    }
}
