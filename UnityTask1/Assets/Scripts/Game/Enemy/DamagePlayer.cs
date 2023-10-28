using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBaseStats player))
        {
            gameObject.TryGetComponent(out EnemyBase enemy);
            player.TakeDamage(enemy.DoDamage());
            Destroy(gameObject);
        }
    }
}
