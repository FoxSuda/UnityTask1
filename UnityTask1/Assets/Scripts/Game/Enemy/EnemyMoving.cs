using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Enemy
{
    public class EnemyMoving : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";

        private Rigidbody rb;
        private Transform player;
        private EnemyBase enemyStats;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag(playerTag).transform;

            enemyStats = GetComponent<EnemyBase>();
        }

        void Update()
        {
            if (player != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;

                direction.y = 0;

                rb.AddForce(direction * enemyStats.GetMovementSpeed(), ForceMode.Force);

                if (rb.velocity.magnitude > enemyStats.GetMovementSpeed())
                {
                    rb.velocity = rb.velocity.normalized * enemyStats.GetMovementSpeed();
                }
            }

            float originalRotationX = transform.rotation.eulerAngles.x;

            transform.LookAt(player);
            transform.rotation = Quaternion.Euler(originalRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

    }
}

