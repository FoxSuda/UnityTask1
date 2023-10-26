using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Enemy configuration", fileName = "Enemy configuration")]
public class EnemyConfiguration : ScriptableObject
{
    public float moveSpeed = 7f;
    public float health = 30f;
    public float damage = 30f;
    public int scoreForEnemy = 1;
}
