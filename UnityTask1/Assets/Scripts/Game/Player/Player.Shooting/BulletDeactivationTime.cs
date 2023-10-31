using UnityEngine;

public class BulletDeactivationTime : MonoBehaviour
{

    private float startTime;
    private float bulletLifetime = 5.0f;

    void OnEnable()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= bulletLifetime)
        {
            gameObject.SetActive(false);
        }
    }
}
