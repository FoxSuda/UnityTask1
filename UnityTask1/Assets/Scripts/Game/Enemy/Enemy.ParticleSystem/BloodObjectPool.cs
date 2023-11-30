using UnityEngine;

namespace Task1.Pool
{
    public class BloodObjectPool : ObjectPoolBase<Task1.EnemyParticleSystem.BloodReleased>
    {
        protected override void OnDestroyPoolObject(Task1.EnemyParticleSystem.BloodReleased poolable)
        {
            Destroy(poolable.gameObject);
        }

        protected override void OnReturnedObjectToPool(Task1.EnemyParticleSystem.BloodReleased poolable)
        {
            poolable.transform.position = Vector3.zero;
            poolable.transform.rotation = Quaternion.identity;
            poolable.Dispose();
            poolable.gameObject.SetActive(false);
        }

        protected override void OnGetObjectFromPool(Task1.EnemyParticleSystem.BloodReleased poolable)
        {
            poolable.gameObject.SetActive(true);
        }

        protected override Task1.EnemyParticleSystem.BloodReleased OnCreatePoolObject()
        {
            GameObject textUIObject = Instantiate(_prefab[0], Vector3.zero, Quaternion.identity, _parent);
            Task1.EnemyParticleSystem.BloodReleased textUI = textUIObject.GetComponent<Task1.EnemyParticleSystem.BloodReleased>();
            return textUI;
        }
    }

}
