using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    IBossAttack iAttack;
    public BossAttackState(BaseBoss owner) : base(owner)
    {
        if (owner is IBossAttack attack)
            iAttack = attack;
        else
            Debug.Log("IBossAttack interface Error");
    }

    public override void Enter()
    {
        Debug.Log("Attack Enter");
    }

    public override void Execute()
    {
        iAttack?.AttackExecute();
    }

    public override void Exit()
    {
        Debug.Log("Attack EXit");
    }
}
