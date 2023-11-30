using System.Collections;
using Task1.Player;
using UnityEngine;

public class PeriodicalEnemyAttack : EnemyBaseAttack
{
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioSource sound;

    private bool isAttacking = false;
    private bool canAttacking = true;
    private float attackInterval = 1.0f;
    private Player _currentAttackTarget;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _currentAttackTarget = player;
            Attack();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            isAttacking = false;

            StopCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (isAttacking && canAttacking)
        {
            sound.Play();
            _currentAttackTarget.TakeDamage(enemyConfiguration.Damage);
            canAttacking = false;
            yield return new WaitForSeconds(attackInterval);
            canAttacking = true;
        }
    }

    public override void Attack()
    {
        if (_currentAttackTarget == null)
        {
            return;
        }
        
        isAttacking = true;
        StartCoroutine(AttackRoutine());
    }
}