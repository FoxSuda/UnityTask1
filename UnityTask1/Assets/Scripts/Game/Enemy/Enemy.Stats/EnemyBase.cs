using Task1.Player;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Task1.EnemyStats
{
    public class EnemyBase : MonoBehaviour
    {

        public float moveSpeed = 7f;
        public float health = 30f;
        public float damage = 30f;
        public int score = 1;

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
