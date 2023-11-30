using System;
using System.Collections;
using UnityEngine;

namespace Task1.EnemyParticleSystem
{
    public class BloodReleased : MonoBehaviour
    {

        private Action<BloodReleased> onBloodReleased;

        public void Initialized(Action<BloodReleased> bloodReleased)
        {
            StartCoroutine(Released());
            onBloodReleased = bloodReleased;
        }

        public void Dispose()
        {
            onBloodReleased = null;
        }

        private IEnumerator Released()
        {
            yield return new WaitForSeconds(1.5f);

            onBloodReleased?.Invoke(this);
        }
    }
}
