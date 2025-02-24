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

        trackingRange = 10f;
        attackRange = 5f;

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

        // 범위를 벗어났을때
        if(distance > attackRange)
        {
            bossFSM.ChangeState(BossState.Tracking);
            return;
        }

        // ###TODO: 공격 패턴 만들어주기
        // 공격 패턴을 클래스화 해서 공격패턴 호출하기
        // 공격 할수 없는 상태
        if(!attackHandler.CanAttack)
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



        // 추적 범위 내 있으면 추적
        if(distance <= trackingRange)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rigidBody.velocity = direction * moveSpeed;
        }

        // 공격 범위 내 있으면 공격 상태로 전이
        if (distance <= attackRange)
        {
            bossFSM.ChangeState(BossState.Attack);
        }

        // 추적 범위 벗어나면 Idle 상태로 전이
        if (distance > trackingRange)
            bossFSM.ChangeState(BossState.Idle);
    }
}
