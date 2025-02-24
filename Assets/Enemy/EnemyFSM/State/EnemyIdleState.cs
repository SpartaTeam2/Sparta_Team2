using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    IEnemyIdle iIdle;
    public EnemyIdleState(BaseEnemy owner) : base(owner)
    {
        if (owner is IEnemyIdle idle)
            iIdle = idle;
        else
            Debug.Log("IBossIdle interface Error");
    }

    public override void Enter()
    {
        Debug.Log("Idle Enter");
    }

    public override void Execute()
    {
        iIdle?.IdleExecute();
    }

    public override void Exit()
    {
        Debug.Log("Idle Exit");
    }
}
