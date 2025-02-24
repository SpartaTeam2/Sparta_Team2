using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,       // 움직임X
    Tracking,   // 추격
    Prowl,      // 배회
    Attack,     // 공격
}

public class EnemyFSM : MonoBehaviour
{
    BaseEnemy owner;        // 몬스터 / 보스 객체

    Dictionary<EnemyState, EnemyBaseState> states;    // 보스가 가지고 있는 상태들
    EnemyBaseState currentState;                     // 현재 상태

    public EnemyFSM(BaseEnemy owner)
    {
        this.owner = owner;
        states = new Dictionary<EnemyState, EnemyBaseState>();

        EnemyBaseState idleState = CreateState(EnemyState.Idle);
        currentState = idleState;

        states.Add(EnemyState.Idle, idleState);
    }

    public void Execute()
    {
        if (currentState == null)
            return;

        currentState.Execute();
    }

    public void ChangeState(EnemyState state)
    {
        // 현재 상태 퇴장
        currentState?.Exit();

        // 다음 상태 가져오기
        if (!states.TryGetValue(state, out currentState))
        {
            EnemyBaseState newState = CreateState(state);
            currentState = newState;

            states.Add(state, newState);
        }

        currentState?.Enter();
    }

    private EnemyBaseState CreateState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                return new EnemyIdleState(owner);

            case EnemyState.Tracking:
                return new EnemyTrackingState(owner);

            case EnemyState.Prowl:
                return new EnemyProwlState(owner);

            case EnemyState.Attack:
                return new EnemyAttackState(owner);
        }

        return null;
    }
}
