using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyEnemy : BaseEnemy, IEnemyIdle, IEnemyTracking, IEnemyAttack
{
    [SerializeField]
    private Transform target;
    private bool nullTarget => target == null;

    protected override void InitEnemy()
    {
        // 임시 데이터
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
        if(nullTarget)
        {
            fsm.ChangeState(EnemyState.Idle);
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        // 추적 범위 내 ( 이동 )
        if(distance <= trackingRange)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            rigidBody.velocity = dir * moveSpeed;

            if(dir.x < 0)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;
        }
        
        // 공격 범위 내 ( 공격 )
        if(distance <= attackRange)
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

        float distance = Vector2.Distance(transform.position, target.position);

        // 범위를 벗어났을때
        if (distance > attackRange)
        {
            fsm.ChangeState(EnemyState.Tracking);
            return;
        }

        // 공격 가능
        if (attackHandler.CanAttack)
        {
            attackHandler.AttackDelay();
            animator.SetTrigger("AttackTrigger");   // 공격 모션 

            // 공격 
        }

        else
            return;
    }
}
