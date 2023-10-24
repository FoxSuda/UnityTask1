using Task1.Player;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Task1.EnemyStats
{
    public class LightEnemyStats : MonoBehaviour, IEnemyStats
    {

        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private float health = 15f;
        [SerializeField] private float damage = 15f;
        [SerializeField] private int score = 1;

        public float GetMovementSpeed()
        {
            return moveSpeed;
        }

        public float GetHealthLevel()
        {
            return health;
        }

        public float DoDamage()
        {
            return damage;
        }

        public void TakeDamage(float damageAmount, PlayerStats player)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                player.AddScore(score);
                Destroy(gameObject);
            }
        }
    }
}

