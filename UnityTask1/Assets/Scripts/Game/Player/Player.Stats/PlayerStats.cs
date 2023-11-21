using Task1.Score;
using UnityEngine;

namespace Task1.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public PlayerConfiguration playerConfiguration;
        [SerializeField] private PlayerScore playerScore;

        [SerializeField] private GameObject soundObject;
        [SerializeField] private AudioSource TakedamageSound;

        private GameObject currentWeapon;

        [SerializeField] private float _health;
        [SerializeField] private int _score;
        [SerializeField] private float _damage;

        private void Awake()
        {
            _health = playerConfiguration.Health;
            _score = playerConfiguration.Score;
            _damage = playerConfiguration.Damage;
        }

        public float GetMovementSpeed()
        {
            return playerConfiguration.MoveSpeed;
        }
        public float GetJumpStrength()
        {
            return playerConfiguration.JumpForce;
        }
        public float GetHealthLevel()
        {
            return _health;
        }
        public float DoDamage()
        {
            return _damage;
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
            return _score;
        }
        public void AddScore(int score)
        {
            _score += score;
            playerScore.AddScore();
        }
        public void TakeDamage(float damageAmount)
        {
            TakedamageSound.Play();
            _health -= damageAmount;
        }

    }
}

