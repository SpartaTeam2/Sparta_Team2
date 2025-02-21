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
    /// ���� ����
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// ���� ����
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// ���� ����
    /// </summary>
    public abstract void Exit();
}
