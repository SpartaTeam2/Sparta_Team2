using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackHandler
{
    private bool canAttack;
    private float attackDelay;
    public bool CanAttack { get; private set; }

    public void InitHandler(float delay)
    {
        canAttack = true;
        attackDelay = delay;
    }

    public void AttackDelay()
    {

    }
}
