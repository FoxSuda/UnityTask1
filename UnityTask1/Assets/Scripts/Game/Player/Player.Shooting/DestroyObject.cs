using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] private GameObject playerGameplay;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerGameplay.GetComponent<PlayerScore>().AddScore();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
