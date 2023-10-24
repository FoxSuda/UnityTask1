using System.Collections;
using Task1.Score;
using UnityEngine;

namespace Task1.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefab;

        [SerializeField] private float minSpawnInterval = 1.0f;
        [SerializeField] private float maxSpawnInterval = 5.0f;

        [SerializeField] private Transform enemyParent;
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
                int spawnTypeIndex = Random.Range(0, enemyPrefab.Length);

                Vector3 randomPointOnPlane = GetRandomPointOnPlane();
                Instantiate(enemyPrefab[spawnTypeIndex], randomPointOnPlane, Quaternion.identity, enemyParent);

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

