using Task1.Player;
using UnityEngine;

namespace Task1.EnemyStats
{
    public class HeavyEnemyStats : EnemyBase
    {
        private void Start()
        {
            moveSpeed = 6f;
            health = 45f;
            damage = 45f;
            score = 1;
        }
    }
}

