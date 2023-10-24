using Task1.Score;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerStats : MonoBehaviour, IPlayerStats
    {

        [SerializeField] private PlayerScore playerScore;

        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 8f;
        [SerializeField] private float health = 100f;
        [SerializeField] private float damage = 15f;
        [SerializeField] private int score = 0;

        public float GetMovementSpeed()
        {
            return moveSpeed;
        }
        public float GetJumpStrength()
        {
            return jumpForce;
        }
        public float GetHealthLevel()
        {
            return health;
        }
        public float DoDamage()
        {
            return damage;
        }
        public float GetScore()
        {
            return score;
        }
        public void AddScore(int score)
        {
            this.score += score;
            playerScore.AddScore();
        }
        public void TakeDamage(float damageAmount)
        {
            health -= damageAmount;
        }

    }
}

