using Task1.Player;
using UnityEngine;

namespace Task1.PlayerBullet
{
    public class DamageEnemy : MonoBehaviour
    {

        private PlayerStats player;

        public void DoDamageToEnemy(PlayerStats player)
        {
            this.player = player;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEnemyStats enemy))
            {
                enemy.TakeDamage(player.DoDamage(), player);
            }

            Destroy(gameObject);
        }
    }
}

