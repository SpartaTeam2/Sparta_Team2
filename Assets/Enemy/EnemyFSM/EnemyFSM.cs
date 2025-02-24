using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,       // ������X
    Tracking,   // �߰�
    Prowl,      // ��ȸ
    Attack,     // ����
}

public class EnemyFSM : MonoBehaviour
{
    BaseEnemy owner;        // ���� / ���� ��ü

    Dictionary<EnemyState, EnemyBaseState> states;    // ������ ������ �ִ� ���µ�
    EnemyBaseState currentState;                     // ���� ����

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
        // ���� ���� ����
        currentState?.Exit();

        // ���� ���� ��������
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
