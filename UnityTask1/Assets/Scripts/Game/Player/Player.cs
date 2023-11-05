using UnityEngine;

namespace Task1.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;

        public void TakeDamage(float damage)
        {
            _playerStats.TakeDamage(damage);
        }
    }
}
