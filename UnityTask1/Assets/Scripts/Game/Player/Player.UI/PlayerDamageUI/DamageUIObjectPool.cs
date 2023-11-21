using UnityEngine;

namespace Task1.Pool
{
    public class DamageUIObjectPool : ObjectPoolBase<Task1.PlayerUI.PlayerDamageUI>
    {
        protected override void OnDestroyPoolObject(Task1.PlayerUI.PlayerDamageUI poolable)
        {
            Destroy(poolable.gameObject);
        }

        protected override void OnReturnedObjectToPool(Task1.PlayerUI.PlayerDamageUI poolable)
        {
            poolable.transform.position = Vector3.zero;
            poolable.transform.rotation = Quaternion.identity;
            poolable.Dispose();
            poolable.gameObject.SetActive(false);
        }

        protected override void OnGetObjectFromPool(Task1.PlayerUI.PlayerDamageUI poolable)
        {
            poolable.gameObject.SetActive(true);
        }

        protected override Task1.PlayerUI.PlayerDamageUI OnCreatePoolObject()
        {
            GameObject textUIObject = Instantiate(_prefab[0], Vector3.zero, Quaternion.identity, _parent);
            Task1.PlayerUI.PlayerDamageUI textUI = textUIObject.GetComponent<Task1.PlayerUI.PlayerDamageUI>();
            return textUI;
        }
    }

}
