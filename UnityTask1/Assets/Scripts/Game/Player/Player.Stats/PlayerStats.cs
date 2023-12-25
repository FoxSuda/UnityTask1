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
        [SerializeField] private int _coins = 0;

        private int coinsChanged = 0;

        public delegate void PlayerChangedDelegate();
        public event PlayerChangedDelegate OnWeaponChanged;
        public event PlayerChangedDelegate OnHealthChanged;
        public event PlayerChangedDelegate OnCoinsChanged;

        private void Awake()
        {
            _health = playerConfiguration.Health;
            _score = playerConfiguration.Score;
            _damage = playerConfiguration.Damage;
            _coins = playerConfiguration.Coins;
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
            OnWeaponChanged?.Invoke();
        }
        public float GetScore()
        {
            return _score;
        }
        public int GetCoins()
        {
            return _coins;
        }
        public void AddCoins(int coins)
        {
            coinsChanged += coins;
            if (coinsChanged >= 10)
            {
                _coins += coinsChanged;
                coinsChanged = 0;
                OnCoinsChanged.Invoke();
            }
        }
        public void AddScore(int score)
        {
            _score += score;
            AddCoins(score);
            playerScore.AddScore();
        }
        public void TakeDamage(float damageAmount)
        {
            TakedamageSound.Play();
            _health -= damageAmount;
            OnHealthChanged?.Invoke();
        }

    }
}

