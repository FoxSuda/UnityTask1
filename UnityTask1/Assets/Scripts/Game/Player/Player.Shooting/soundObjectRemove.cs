using System;
using System.Collections;
using System.Collections.Generic;
using Task1.EnemyParticleSystem;
using Unity.VisualScripting;
using UnityEngine;

public class soundObjectRemove : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Released());
    }

    private IEnumerator Released()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
