using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    // FSM
    protected EnemyFSM fsm;

    // handler
    protected EnemyAttackHandler attackHandler;

    // Component
    protected Animator animator;
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;

    // layerMask
    protected LayerMask playerLayer;

    // ���� ������
    protected int hp;               // ����ü��
    protected int maxHP;            // �ִ�ü��
    protected int damage;           // ���ݷ�
    protected float moveSpeed;      // �̵� �ӵ�
    protected float attackDelay;    // ���� ������

    // ����
    protected float trackingRange;
    protected float attackRange;

    // GET SET
    public Animator Animator { get { return animator; } }

    private void Start()
    {
        InitComponent();
        InitEnemy();
    }

    private void Update()
    {
        fsm.Execute();
    }

    protected void InitComponent()
    {
        // fsm
        fsm = new EnemyFSM(this);

        // component
        attackHandler   = GetComponentInChildren<EnemyAttackHandler>();
        animator        = GetComponentInChildren<Animator>();
        rigidBody       = GetComponentInChildren<Rigidbody2D>();
        spriteRenderer  = GetComponentInChildren<SpriteRenderer>();

        // layermask
        playerLayer = LayerMask.GetMask("Player");
    }

    protected abstract void InitEnemy();

    protected Vector2 TargetDirection(Transform target)
    {
        return (target.position - transform.position).normalized;
    }

    protected void LookAtTarget(Transform target)
    {
        Vector2 dir = TargetDirection(target);

        spriteRenderer.flipX = dir.x > 0 ? true : false;
    }

    public void GetDamage(float damage)
    {
        Debug.Log($"enemy Get Damage {damage}");
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        // ���� ����
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        // ���� ����
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
#endif
    }
}
