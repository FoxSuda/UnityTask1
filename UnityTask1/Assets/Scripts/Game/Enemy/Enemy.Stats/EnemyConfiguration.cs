using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Enemy configuration", fileName = "Enemy configuration")]
public class EnemyConfiguration : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private int scoreForEnemy;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float Health { get => health; set => health = value; }
    public float Damage { get => damage; set => damage = value; }
    public int ScoreForEnemy { get => scoreForEnemy; set => scoreForEnemy = value; }
}
