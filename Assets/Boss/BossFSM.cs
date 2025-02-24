using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    Tracking,
    Attack
}

public class BossFSM
{
    BaseBoss owner;                                 // FSM�� ����ϴ� ���� ��ü

    Dictionary<BossState, BossBaseState> states;    // ������ ������ �ִ� ���µ�
    BossBaseState currentState;                     // ���� ����

    public BossFSM(BaseBoss owner)
    {
        this.owner = owner;
        states = new Dictionary<BossState, BossBaseState>();

        BossBaseState idleState = CreateState(BossState.Idle);
        currentState = idleState;

        states.Add(BossState.Idle, idleState);
    }

    public void Execute()
    {
        if (currentState == null)
            return;

        currentState.Execute();
    }

    public void ChangeState(BossState state)
    {
        // ���� ���� ����
        currentState?.Exit();   

        // ���� ���� ��������
        if(!states.TryGetValue(state, out currentState))
        {
            BossBaseState newState = CreateState(state);
            currentState = newState;

            states.Add(state, newState);
        }

        currentState?.Enter();
    }

    private BossBaseState CreateState(BossState state)
    {
        switch(state)
        {
            case BossState.Idle:
                return new BossIdleState(owner);
                
            case BossState.Tracking:
                return new BossTrackingState(owner);

            case BossState.Attack:
                return new BossAttackState(owner);
        }

        return null;
    }
}
