using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBoss : MonoBehaviour
{
    // FSM
    protected BossFSM bossFSM;

    // handler
    protected BossAttackHandler attackHandler;

    // Component
    [SerializeField] protected Animator animator;
    [SerializeField] protected Rigidbody2D rigidBody;

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
        InitBoss();        
        InitComponent();
    }

    private void Update()
    {
        bossFSM.Execute();
    }

    protected void InitComponent()
    {
        // fsm
        bossFSM = new BossFSM(this);

        // handler
        attackHandler = new BossAttackHandler();

        // component
        animator  = GetComponentInChildren<Animator>();
        rigidBody = GetComponentInChildren<Rigidbody2D>();

        // layermask
        playerLayer = LayerMask.GetMask("Player");
    }

    protected abstract void InitBoss();


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
