using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    IBossIdle iIdle;
    public BossIdleState(BaseBoss owner) : base(owner)
    {
        if (owner is IBossIdle attack)
            iIdle = attack;
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
