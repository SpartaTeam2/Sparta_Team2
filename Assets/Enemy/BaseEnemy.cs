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
        attackHandler = GetComponentInChildren<EnemyAttackHandler>();
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponentInChildren<Rigidbody2D>();

        // layermask
        playerLayer = LayerMask.GetMask("Player");
    }

    protected abstract void InitEnemy();


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
