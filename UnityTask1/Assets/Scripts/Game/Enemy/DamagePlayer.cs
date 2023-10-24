using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayerStats player))
        {
            gameObject.TryGetComponent(out IEnemyStats enemy);
            player.TakeDamage(enemy.DoDamage());
            Destroy(gameObject);
        }
    }
}
