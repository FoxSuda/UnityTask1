using System.Collections.Generic;
using UnityEngine;

public class ShootingObjectPool : MonoBehaviour
{
    public static ShootingObjectPool bulletSharedInstance;
    public List<GameObject> BulletObjects;
    [SerializeField] private GameObject bulletObjectToPool;
    [SerializeField] private int bulletAmountToPool = 45;

    [SerializeField] private Transform bulletParent;

    void Awake()
    {
        bulletSharedInstance = this;
    }

    void Start()
    {
        BulletObjects = new List<GameObject>();
        GameObject tmp;
        for (int j = 0; j < bulletAmountToPool; j++)
        {
            tmp = Instantiate(bulletObjectToPool, bulletParent);
            tmp.SetActive(false);
            BulletObjects.Add(tmp);
        }
    }

    public GameObject GetBulletPooledObject()
    {
        for (int i = 0; i < bulletAmountToPool; i++)
        {
            if (!BulletObjects[i].activeInHierarchy)
            {
                return BulletObjects[i];
            }
        }
        return null;
    }
}
