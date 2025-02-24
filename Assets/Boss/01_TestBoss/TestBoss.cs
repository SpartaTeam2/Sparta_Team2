using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : BaseBoss, IBossIdle, IBossAttack, IBossTracking
{
    private Transform target;

    protected override void InitBoss()
    {
        maxHP = 100;
        hp = maxHP;

        damage = 10;
        moveSpeed = 5f;
        attackDelay = 2f;

        trackingRange = 30f;
        attackRange = 15f;

        attackHandler.InitHandler(attackDelay);
    }

    public void IdleExecute()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, trackingRange, playerLayer);

        if (targetCollider != null)
        {
            target = targetCollider.transform;
            bossFSM.ChangeState(BossState.Tracking);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
            target = null;
        }

    }

    public void AttackExecute()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        // ������ �������
        if(distance > attackRange)
        {
            bossFSM.ChangeState(BossState.Tracking);
            return;
        }

        // ���� ����
        if(attackHandler.CanAttack)
        {
            attackHandler.AttackDelay();
            pattern.TestPattern_1(transform, target);
        }
        // ���� ��Ÿ��
        else
        {
            
            return;
        }
    }

    public void TrackingExecute()
    {
        if (target == null)
        {
            bossFSM.ChangeState(BossState.Idle);
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);



        // ���� ���� �� ������ ����
        if(distance <= trackingRange)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rigidBody.velocity = direction * moveSpeed;
        }

        // ���� ���� �� ������ ���� ���·� ����
        if (distance <= attackRange)
        {
            rigidBody.velocity = Vector2.zero;
            bossFSM.ChangeState(BossState.Attack);
        }

        // ���� ���� ����� Idle ���·� ����
        if (distance > trackingRange)
            bossFSM.ChangeState(BossState.Idle);
    }
}
