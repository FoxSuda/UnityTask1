using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnObjectPool : MonoBehaviour
{
    public static EnemySpawnObjectPool enemySharedInstance;
    public List<GameObject> EnemyObjects;
    [SerializeField] private GameObject[] enemyObjectToPool = new GameObject[3];
    [SerializeField] private int eachTypeEnemyAmountToPool = 20;

    [SerializeField] private Transform enemyParent;

    int randomIndex;

    void Awake()
    {
        enemySharedInstance = this;
    }

    void Start()
    {
        EnemyObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < enemyObjectToPool.Length; i++)
        {
            for (int j = 0; j < eachTypeEnemyAmountToPool; j++)
            {
                tmp = Instantiate(enemyObjectToPool[i], enemyParent);
                tmp.SetActive(false);
                EnemyObjects.Add(tmp);
            }
        }
    }

    public GameObject GetEnemyPooledObject()
    {
        for (int i = 0; i < eachTypeEnemyAmountToPool * enemyObjectToPool.Length; i++)
        {
            randomIndex = Random.Range(0, eachTypeEnemyAmountToPool * enemyObjectToPool.Length);
            if (!EnemyObjects[randomIndex].activeInHierarchy)
            {
                return EnemyObjects[randomIndex];
            }
        }
        return null;
    }
}
