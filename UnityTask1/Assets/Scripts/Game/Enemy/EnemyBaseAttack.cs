using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseAttack : MonoBehaviour
{
    [SerializeField] protected EnemyConfiguration enemyConfiguration;
    public abstract void Attack();
}
