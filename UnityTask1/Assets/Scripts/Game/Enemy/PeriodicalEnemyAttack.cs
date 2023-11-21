using System.Collections;
using Task1.Player;
using UnityEngine;

public class PeriodicalEnemyAttack : EnemyBaseAttack
{
    [HideInInspector] public GameObject soundObject;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioSource sound;
    [SerializeField] private int soundCategory = 0;

    private bool isAttacking = false;
    private float attackInterval = 1.0f;
    private Player _currentAttackTarget;
    private IEnumerator _attackRoutine;

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
            if (_attackRoutine == null)
            {
                _attackRoutine = AttackRoutine();
            }

            StopCoroutine(_attackRoutine);
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (isAttacking)
        {
            sound.Play();
            _currentAttackTarget.TakeDamage(enemyConfiguration.Damage);
            yield return new WaitForSeconds(attackInterval);
        }
    }

    public override void Attack()
    {
        if (_currentAttackTarget == null)
        {
            return;
        }
        
        if (_attackRoutine == null)
        {
            _attackRoutine = AttackRoutine();
        }
        
        isAttacking = true;
        StartCoroutine(_attackRoutine);
    }
}