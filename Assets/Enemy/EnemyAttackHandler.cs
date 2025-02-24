using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [SerializeField] private bool canAttack;
    [SerializeField] private float attackDelay;

    public bool CanAttack { get { return canAttack; } }

    public void InitHandler(float delay)
    {
        canAttack = true;
        attackDelay = delay;
    }

    public void AttackDelay()
    {
        canAttack = false;
        StartCoroutine(OnDelay());
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
