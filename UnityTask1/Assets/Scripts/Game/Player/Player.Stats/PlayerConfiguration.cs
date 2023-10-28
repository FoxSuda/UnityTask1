using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Player configuration", fileName = "Player configuration")]
public class PlayerConfiguration : ScriptableObject
{
    public float moveSpeed = 7f;
    public float jumpForce = 8f;
    public float health = 100f;
    public float damage = 15f;
    public int score = 0;
}
