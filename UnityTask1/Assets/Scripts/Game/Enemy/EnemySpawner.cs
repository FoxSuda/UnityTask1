using System.Collections;
using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject soundObject;

        [SerializeField] private float minSpawnInterval = 1.0f;
        [SerializeField] private float maxSpawnInterval = 5.0f;

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private EnemyObjectPool _enemyObjectPool;
        

        private void Start()
        {
            StartCoroutine(SpawnCubesRandomly());
        }

        IEnumerator SpawnCubesRandomly()
        {
            while (true)
            {
                float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

                Vector3 randomPointOnPlane = GetRandomPointOnPlane();
                var enemy = _enemyObjectPool.Pool.Get();
                if (enemy != null)
                {
                    enemy.Initialize(randomPointOnPlane, ReleaseEnemy);
                    enemy.soundObject = soundObject;
                }
                
                // GameObject newEnemy = EnemySpawnObjectPool.enemySharedInstance.GetEnemyPooledObject();
                //
                // if (newEnemy != null)
                // {
                //     newEnemy.transform.position = randomPointOnPlane;
                //     newEnemy.transform.rotation = Quaternion.identity;
                //     newEnemy.SetActive(true);
                //
                //     DamagePlayer damagePlayer = newEnemy.GetComponent<DamagePlayer>();
                //     damagePlayer.soundObject = soundObject;
                // }

                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void ReleaseEnemy(EnemyBase enemy)
        {
            _enemyObjectPool.Pool.Release(enemy);
        }

        Vector3 GetRandomPointOnPlane()
        {
            int startIndex = Random.Range(0, spawnPoints.Length);
            int endIndex;

            if (startIndex == spawnPoints.Length - 1)
            {
                endIndex = 0;
            }
            else
            {
                endIndex = startIndex + 1;
            }

            Transform startTransform = spawnPoints[startIndex];
            Transform endTransform = spawnPoints[endIndex];

            Vector3 randomPoint = Vector3.Lerp(startTransform.position, endTransform.position, Random.value);

            return randomPoint;
        }
    }
}

