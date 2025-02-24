using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProwlState : EnemyBaseState
{
    IEnemyProwl iProwl;
    public EnemyProwlState(BaseEnemy owner) : base(owner)
    {
        if (owner is IEnemyProwl prowl)
            iProwl = prowl;
        else
            Debug.Log("IBossTracking interface Error");
    }

    public override void Enter()
    {
        owner.Animator.SetBool("Prowl", true);
    }

    public override void Execute()
    {
        iProwl?.ProwlExecute();
    }

    public override void Exit()
    {
        owner.Animator.SetBool("Prowl", false);
    }
}
