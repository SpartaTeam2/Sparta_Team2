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

    // 몬스터 데이터
    protected int hp;               // 현재체력
    protected int maxHP;            // 최대체력
    protected int damage;           // 공격력
    protected float moveSpeed;      // 이동 속도
    protected float attackDelay;    // 공격 딜레이

    // 범위
    protected float trackingRange;
    protected float attackRange;

    // GET SET
    public Animator Animator { get { return animator; } }
    public int Damage {  get { return damage; } }

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

    protected Vector3 TargetDirection(Vector3 target)
    {
        return (target - transform.position).normalized;
    }

    protected void LookAtTarget(Vector3 target)
    {
        Vector3 dir = TargetDirection(target);

        spriteRenderer.flipX = dir.x > 0 ? true : false;
    }

    public void GetDamage(float damage)
    {
        hp -= (int)damage;
        if(hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

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
