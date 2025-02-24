using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBoss : MonoBehaviour
{
    // FSM
    protected BossFSM bossFSM;

    // handler
    protected BossAttackHandler attackHandler;

    // boss Pattern
    protected BossPattern pattern;

    // Component
    protected Animator animator;
    protected Rigidbody2D rigidBody;

    // layerMask
    protected LayerMask playerLayer;

    // 보스 데이터
    protected int hp;               // 현재체력
    protected int maxHP;            // 최대체력
    protected int damage;           // 공격력
    protected float moveSpeed;      // 이동 속도
    protected float attackDelay;    // 공격 딜레이

    // 범위
    protected float trackingRange;
    protected float attackRange;
    private void Start()
    {
        InitComponent();
        InitBoss();        
    }

    private void Update()
    {
        bossFSM.Execute();
    }

    protected void InitComponent()
    {
        // fsm
        bossFSM = new BossFSM(this);

        // component
        attackHandler   = GetComponentInChildren<BossAttackHandler>();
        pattern         = GetComponentInChildren<BossPattern>();
        animator        = GetComponentInChildren<Animator>();
        rigidBody       = GetComponentInChildren<Rigidbody2D>();

        // layermask
        playerLayer = LayerMask.GetMask("Player");
    }

    protected abstract void InitBoss();


    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        // 추적 범위
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        // 공격 범위
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
#endif
    }
}
