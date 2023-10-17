using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    [SerializeField] private float minSpawnInterval = 1.0f;
    [SerializeField] private float maxSpawnInterval = 5.0f;

    private Collider planeCollider;

    private void Start()
    {
        planeCollider = GetComponent<Collider>();
        StartCoroutine(SpawnCubesRandomly());
    }

    IEnumerator SpawnCubesRandomly()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            Vector3 randomPointOnPlane = GetRandomPointOnPlane();
            Instantiate(cubePrefab, randomPointOnPlane, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomPointOnPlane()
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(planeCollider.bounds.min.x, planeCollider.bounds.max.x),
            planeCollider.bounds.max.y,
            Random.Range(planeCollider.bounds.min.z, planeCollider.bounds.max.z)
        );

        return randomPoint;
    }
}
