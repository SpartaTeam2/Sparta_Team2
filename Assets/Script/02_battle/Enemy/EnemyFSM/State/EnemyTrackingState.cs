using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrackingState : EnemyBaseState
{
    IEnemyTracking iTracking;
    public EnemyTrackingState(BaseEnemy owner) : base(owner)
    {
        if (owner is IEnemyTracking tracking)
            iTracking = tracking;
        else
            Debug.Log("IBossTracking interface Error");
    }

    public override void Enter()
    {
        owner.Animator.SetBool("Tracking", true);
    }

    public override void Execute()
    {
        iTracking?.TrackingExecute();
    }

    public override void Exit()
    {
        owner.Animator.SetBool("Tracking", false);
    }
}
