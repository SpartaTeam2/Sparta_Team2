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
        // �ӽ� ������
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

        // ���� ���� �� ( �̵� )
        if(distance <= trackingRange)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            rigidBody.velocity = dir * moveSpeed;

            if(dir.x < 0)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;
        }
        
        // ���� ���� �� ( ���� )
        if(distance <= attackRange)
        {
            rigidBody.velocity = Vector2.zero;
            fsm.ChangeState(EnemyState.Attack);
        }

        // ���� ���� ��
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

        // ������ �������
        if (distance > attackRange)
        {
            fsm.ChangeState(EnemyState.Tracking);
            return;
        }

        // ���� ����
        if (attackHandler.CanAttack)
        {
            attackHandler.AttackDelay();
            animator.SetTrigger("AttackTrigger");   // ���� ��� 

            // ���� 
        }

        else
            return;
    }
}
