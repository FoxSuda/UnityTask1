using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Player configuration", fileName = "Player configuration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private int score = 0;
    [SerializeField] private int coins = 0;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public float Health { get => health; set => health = value; }
    public float Damage { get => damage; set => damage = value; }
    public int Score { get => score; set => score = value; }
    public int Coins { get => coins; set => coins = value; }
}
