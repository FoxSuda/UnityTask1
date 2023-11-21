using UnityEngine;
using UnityEngine.Pool;

public abstract class ObjectPoolBase<T> : MonoBehaviour where T : class
{
    [SerializeField] protected GameObject[] _prefab;
    [SerializeField] protected Transform _parent;
    [SerializeField] protected  bool collectionChecks = true;
    [SerializeField] protected  int defaultPoolSize = 15;
    [SerializeField] protected  int maximumPoolSize = 30;
    
    private IObjectPool<T> _pool;
    
    public IObjectPool<T> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<T>(OnCreatePoolObject, 
                    OnGetObjectFromPool, 
                    OnReturnedObjectToPool,
                    OnDestroyPoolObject, 
                    collectionChecks, 
                    defaultPoolSize, 
                    maximumPoolSize);
            }

            return _pool;
        }
    }

    protected abstract void OnDestroyPoolObject(T poolable);

    protected abstract void OnReturnedObjectToPool(T poolable);
    protected abstract void OnGetObjectFromPool(T poolable);

    protected abstract T OnCreatePoolObject();
}