public interface IPlayerStats
{
    float GetMovementSpeed();
    float GetJumpStrength();
    float GetHealthLevel();
    float DoDamage();
    void TakeDamage(float damageAmount);
}
