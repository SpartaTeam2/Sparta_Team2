using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    protected BaseEnemy owner;

    protected EnemyBaseState(BaseEnemy owner)
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
