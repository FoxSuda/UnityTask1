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
            _health = enemyConfiguration.Health;
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

        public void TakeDamage(float damageAmount, PlayerStats player)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                player.AddScore(enemyConfiguration.ScoreForEnemy);
                Destroy(gameObject);
            }
        }
    }
}
