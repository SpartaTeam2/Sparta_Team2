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
        Debug.Log("Tracking Enter");
    }

    public override void Execute()
    {
        iProwl?.ProwlExecute();
    }

    public override void Exit()
    {
        Debug.Log("Tracking Exit");
    }
}
