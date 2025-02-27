using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UglyBoss : BaseEnemy, IEnemyIdle, IEnemyTracking, IEnemyAttack
{
    private Transform target;
    private bool nullTarget => target == null;

    private BossPattern pattern;
    protected override void InitEnemy()
    {
        //// 임시 데이터
        //maxHP = 100;
        hp = maxHP;

        //damage = 10;
        //moveSpeed = 5f;
        attackDelay = 0.5f;

        //trackingRange = 10f;
        //attackRange = 8f;

        attackHandler.InitHandler(attackDelay);
        hpbar.InitHPbar(this);

        pattern = GetComponentInChildren<BossPattern>();
        pattern.InitPattern(attackHandler, this);
    }

    public void IdleExecute()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, trackingRange, playerLayer);

        if (targetCollider != null)
        {
            target = targetCollider.transform;
            fsm.ChangeState(EnemyState.Tracking);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
            target = null;
        }
    }

    public void TrackingExecute()
    {
        if (nullTarget)
        {
            fsm.ChangeState(EnemyState.Idle);
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        // 추적 범위 내 ( 이동 )
        if (distance <= trackingRange)
        {
            Vector2 dir = TargetDirection(target.position);
            rigidBody.velocity = dir * moveSpeed;

            LookAtTarget(target.position);
        }

        // 공격 범위 내 ( 공격 )
        if (distance <= attackRange)
        {
            rigidBody.velocity = Vector2.zero;
            fsm.ChangeState(EnemyState.Attack);
        }

        // 추적 범위 밖
        if (distance > trackingRange)
            fsm.ChangeState(EnemyState.Idle);
    }

    public void AttackExecute()
    {
        if (nullTarget)
        {
            fsm.ChangeState(EnemyState.Idle);
            return;
        }
        
        if (attackHandler.isAttacking)
        {
            LookAtTarget(target.position);
            return;
        }
        float distance = Vector2.Distance(transform.position, target.position);

        // 범위를 벗어났을때
        if (distance > attackRange)
        {
            fsm.ChangeState(EnemyState.Tracking);
            return;
        }

        // 공격 가능
        if (attackHandler.canAttack)
        {
            attackHandler.AttackDelay();

            int patternCount = Enum.GetValues(typeof(PatternName)).Length;
            PatternName randomPattern = (PatternName)Random.Range(0,patternCount);

            pattern.OnPattern(transform, target, randomPattern);
        }
    }
}
