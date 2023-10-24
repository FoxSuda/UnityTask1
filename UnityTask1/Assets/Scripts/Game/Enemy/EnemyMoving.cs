using UnityEngine;

namespace Task1.Enemy
{
    public class EnemyMoving : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";

        private Rigidbody rb;
        private Transform player;
        private IEnemyStats enemyStats;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag(playerTag).transform;

            enemyStats = GetComponent<IEnemyStats>();
        }

        void Update()
        {
            if (player != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.AddForce(direction * enemyStats.GetMovementSpeed(), ForceMode.Force);

                if (rb.velocity.magnitude > enemyStats.GetMovementSpeed())
                {
                    rb.velocity = rb.velocity.normalized * enemyStats.GetMovementSpeed();
                }
            }
        }

    }
}

