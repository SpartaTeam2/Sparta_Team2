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
    protected EnemyHPbar hpbar;

    // layerMask
    protected LayerMask playerLayer;

    // ���� ������
    [Header("���� ������ �߰����ּ���")]
    protected int hp;               // ����ü��
    protected float attackDelay;    // ���� ������
    [SerializeField] protected int maxHP;           // �ִ�ü��
    [SerializeField] protected int damage;          // ���ݷ�
    [SerializeField] protected float moveSpeed;     // �̵� �ӵ�
    [SerializeField] protected float trackingRange; // ���� ����
    [SerializeField] protected float attackRange;   // ���� ����

    [Header("EXP")]
    [SerializeField] private GameObject expPrefab;

    // GET SET
    public Animator Animator { get { return animator; } }
    public int Damage {  get { return damage; } }
    public int MaxHP {  get { return maxHP; } }
    public int HP {  get { return hp; } }

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
        hpbar           = GetComponentInChildren<EnemyHPbar>();

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
        hpbar.UpdateHPBar();
        if(hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

    public void Dead()
    {
        Instantiate(expPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
