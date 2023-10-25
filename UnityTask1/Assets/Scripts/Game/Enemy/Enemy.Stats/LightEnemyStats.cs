namespace Task1.EnemyStats
{
    public class LightEnemyStats : EnemyBase
    {
        private void Start()
        {
            moveSpeed = 8f;
            health = 15f;
            damage = 15f;
            score = 1;
        }
    }
}

