using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrackingState : BossBaseState
{
    IBossTracking iTracking;
    public BossTrackingState(BaseBoss owner) : base(owner)
    {
        if (owner is IBossTracking attack)
            iTracking = attack;
        else
            Debug.Log("IBossTracking interface Error");
    }

    public override void Enter()
    {
        Debug.Log("Tracking Enter");
    }

    public override void Execute()
    {
        iTracking?.TrackingExecute();
    }

    public override void Exit()
    {
        Debug.Log("Tracking Exit");
    }
}
