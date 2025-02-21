using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState
{
    protected BaseBoss owner;

    protected BossBaseState(BaseBoss owner)
    {
        this.owner = owner;
    }


    /// <summary>
    /// 상태 진입
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// 상태 실행
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// 상태 퇴장
    /// </summary>
    public abstract void Exit();
}
