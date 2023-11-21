using Task1.EnemyStats;
using UnityEngine;

namespace Task1.Enemy
{
    public class EnemyObjectPool : ObjectPoolBase<EnemyBase>
    {
        protected override void OnDestroyPoolObject(EnemyBase poolable)
        {
            Destroy(poolable.gameObject);
        }

        protected override void OnReturnedObjectToPool(EnemyBase poolable)
        {
            poolable.transform.position = Vector3.zero;
            poolable.transform.rotation = Quaternion.identity;
            poolable.Dispose();
            poolable.gameObject.SetActive(false);
        }

        protected override void OnGetObjectFromPool(EnemyBase poolable)
        {
            poolable.gameObject.SetActive(true);
        }

        protected override EnemyBase OnCreatePoolObject()
        {
            int randomIndex = Random.Range(0, _prefab.Length);
            GameObject enemyObject = Instantiate(_prefab[randomIndex], Vector3.zero, Quaternion.identity, _parent);
            EnemyBase enemy = enemyObject.GetComponent<EnemyBase>();
            return enemy;
        }
    }
}