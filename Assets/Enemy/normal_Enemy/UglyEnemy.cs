using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyEnemy : BaseEnemy, IEnemyIdle, IEnemyTracking, IEnemyAttack
{
    [SerializeField] private GameObject bulletPrefab;

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
        attackRange = 8f;

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
            Vector2 dir = TargetDirection(target.position);
            rigidBody.velocity = dir * moveSpeed;

            LookAtTarget(target.position);
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

        if(attackHandler.isAttacking)
        {
            LookAtTarget(target.position);
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
        if (attackHandler.canAttack)
        {
            attackHandler.AttackDelay();
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        //float lineTime = GuideLine.Instance.OnTrackingLine(transform, target, 0.1f);
        //yield return new WaitForSeconds(lineTime);

        // ����
        EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
        bullet.transform.position = transform.position;
        bullet.GetComponent<EnemyBullet>().Damage = damage;
        //  �Ѿ� ���� / �̵�
        Vector2 dir = TargetDirection(target.position);
        bullet.Shot(dir);
        animator.SetTrigger("AttackTrigger");   // ���� ��� 

        // ��� ��� �� ������ ���� ��
        yield return new WaitForSeconds(0.4f);
        attackHandler.EndAttack();
    }
}
