using Task1.Pool;
using UnityEngine;

namespace Task1.EnemyParticleSystem
{
    public class BloodParticleInstantiate : MonoBehaviour
    {
        [SerializeField] private BloodObjectPool bloodObjectPool;

        public void BloodInstantiate(Transform objHit, Transform objAttack)
        {
            var pooledBloodParticle = bloodObjectPool.Pool.Get();
            if (pooledBloodParticle != null)
            {
                pooledBloodParticle.transform.position = objHit.position;
                pooledBloodParticle.transform.LookAt(objAttack.position);
                pooledBloodParticle.Initialized(ReleaseBlood);
            }
        }

        private void ReleaseBlood(BloodReleased blood)
        {
            bloodObjectPool.Pool.Release(blood);
        }
    }
}

