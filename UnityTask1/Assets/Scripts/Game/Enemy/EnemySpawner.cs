using System.Collections;
using UnityEngine;

namespace Task1.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject soundObject;

        [SerializeField] private float minSpawnInterval = 1.0f;
        [SerializeField] private float maxSpawnInterval = 5.0f;

        [SerializeField] private Transform[] spawnPoints;

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
                GameObject newEnemy = EnemySpawnObjectPool.enemySharedInstance.GetEnemyPooledObject();

                if (newEnemy != null)
                {
                    newEnemy.transform.position = randomPointOnPlane;
                    newEnemy.transform.rotation = Quaternion.identity;
                    newEnemy.SetActive(true);

                    DamagePlayer damagePlayer = newEnemy.GetComponent<DamagePlayer>();
                    damagePlayer.soundObject = soundObject;
                }

                yield return new WaitForSeconds(spawnInterval);
            }
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

