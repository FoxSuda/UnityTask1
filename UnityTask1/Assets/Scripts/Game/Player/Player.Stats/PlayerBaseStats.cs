using Task1.Score;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerBaseStats : MonoBehaviour
    {
        public PlayerConfiguration playerConfiguration;
        [SerializeField] private PlayerScore playerScore;

        private GameObject currentWeapon;

        private float _health;
        private int _score;

        private void Awake()
        {
            _health = playerConfiguration.health;
            _score = playerConfiguration.score;
        }

        public float GetMovementSpeed()
        {
            return playerConfiguration.moveSpeed;
        }
        public float GetJumpStrength()
        {
            return playerConfiguration.jumpForce;
        }
        public float GetHealthLevel()
        {
            return playerConfiguration.health;
        }
        public float DoDamage()
        {
            return playerConfiguration.damage;
        }
        public GameObject GetCurrentWeapon()
        {
            return currentWeapon;
        }
        public void SetCurrentWeapon(GameObject currentWeapon)
        {
            this.currentWeapon = currentWeapon;
        }
        public float GetScore()
        {
            return playerConfiguration.score;
        }
        public void AddScore(int score)
        {
            _score += score;
            playerScore.AddScore();
        }
        public void TakeDamage(float damageAmount)
        {
            _health -= damageAmount;
        }

    }
}
