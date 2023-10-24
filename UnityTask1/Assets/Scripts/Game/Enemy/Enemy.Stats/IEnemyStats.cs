using Task1.Player;

public interface IEnemyStats
{
    float GetMovementSpeed();
    float GetHealthLevel();
    float DoDamage();
    void TakeDamage(float damageAmount, PlayerStats player);
}
