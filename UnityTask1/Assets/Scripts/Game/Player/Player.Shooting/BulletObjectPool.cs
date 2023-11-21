using UnityEngine;

namespace Task1.Pool
{
    public class BulletObjectPool : ObjectPoolBase<Task1.Player.PlayerBullet>
    {
        protected override void OnDestroyPoolObject(Task1.Player.PlayerBullet poolable)
        {
            Destroy(poolable.gameObject);
        }

        protected override void OnReturnedObjectToPool(Task1.Player.PlayerBullet poolable)
        {
            poolable.transform.position = Vector3.zero;
            poolable.transform.rotation = Quaternion.identity;
            poolable.Dispose();
            poolable.gameObject.SetActive(false);
        }

        protected override void OnGetObjectFromPool(Task1.Player.PlayerBullet poolable)
        {
            poolable.gameObject.SetActive(true);
        }

        protected override Task1.Player.PlayerBullet OnCreatePoolObject()
        {
            GameObject bulletObject = Instantiate(_prefab[0], Vector3.zero, Quaternion.identity, _parent);
            Task1.Player.PlayerBullet bullet = bulletObject.GetComponent<Task1.Player.PlayerBullet>();
            return bullet;
        }
    }

}
