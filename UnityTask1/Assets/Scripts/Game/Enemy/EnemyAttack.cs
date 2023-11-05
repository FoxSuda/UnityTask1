using System.Collections;
using System.Collections.Generic;
using Task1.EnemyStats;
using Task1.Player;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector] public GameObject soundObject;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private int soundCategory = 0;

    private bool isAttacking = false;
    private float attackInterval = 1.0f;
    private float attackTimer = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBaseStats player))
        {
            gameObject.TryGetComponent(out EnemyBase enemy);
            isAttacking = true;
            if (Time.time - attackTimer >= attackInterval)
            {
                StartCoroutine(AttackPeriodically(player, enemy));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBaseStats player))
        {
            isAttacking = false;
        }
    }

    private IEnumerator AttackPeriodically(PlayerBaseStats player, EnemyBase enemy)
    {
        while (isAttacking)
        {
            soundObject.GetComponent<Sound>().PlaySound(damageSound, soundCategory);
            player.TakeDamage(enemy.DoDamage());
            attackTimer = Time.time;
            yield return new WaitForSeconds(attackInterval);
        }
    }
}
