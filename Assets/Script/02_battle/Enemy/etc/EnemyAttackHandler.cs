using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    public bool canAttack {  get; private set; }
    public bool isAttacking {  get; private set; }

    [SerializeField] private float attackDelay;

    public void InitHandler(float delay)
    {
        canAttack = true;
        isAttacking = false;
        attackDelay = delay;
    }

    public void AttackDelay()
    {
        canAttack = false;
        isAttacking = true;
        StartCoroutine(OnDelay());
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
