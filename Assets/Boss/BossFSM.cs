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
    BaseBoss owner;                                 // FSM을 사용하는 보스 객체

    Dictionary<BossState, BossBaseState> states;    // 보스가 가지고 있는 상태들
    BossBaseState currentState;                     // 현재 상태

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
        // 현재 상태 퇴장
        currentState?.Exit();   

        // 다음 상태 가져오기
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
