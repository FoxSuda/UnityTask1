using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundBullet : MonoBehaviour
{
    public void PlaySoundHitBullet(GameObject soundPrefab, Transform soundPrefabParent)
    {
        Instantiate(soundPrefab, gameObject.transform.position, Quaternion.identity, soundPrefabParent);
    }
}
