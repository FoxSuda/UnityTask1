using Task1.Player;
using UnityEngine;

namespace Task1.EnemyStats
{
    public class HeavyEnemyStats : MonoBehaviour, IEnemyStats
    {

        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float health = 45f;
        [SerializeField] private float damage = 45f;
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

