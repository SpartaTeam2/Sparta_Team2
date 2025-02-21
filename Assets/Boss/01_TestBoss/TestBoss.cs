using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : BaseBoss, IBossAttack, IBossIdle, IBossTracking
{
    protected override void InitBoss()
    {
        Debug.Log("test boss √ ±‚»≠");
    }

    public void AttackExecute()
    {
        Debug.Log("test Attack Execute");
    }

    public void IdleExecute()
    {
        Debug.Log("test Idle Execute");
    }

    public void TrackingExecute()
    {
        Debug.Log("test Tracking Execute");
    }
}
