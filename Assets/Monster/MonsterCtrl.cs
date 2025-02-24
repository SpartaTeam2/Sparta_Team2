using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    [Header("몬스터 기본 스탯")]
    public float MaxHP;
    public float Speed;
    public float AttackDamage;
    public float ChaseDis;
    public float FightDis;

    [Header("몬스터 현재 전투 정보")]
    public GameObject ChaseThing;
    public float HP;
    public float AttackTime;
    bool CanAttack;

    [Header("몬스터 공격 효과")]
    public GameObject AttackPrefabs;

    [Header("몬스터 피격 효과")]
    public GameObject HitPrefabs;
    public GameObject Exps;
    public AudioSource _audioSource;
    public AudioClip HitSound;
    public AudioClip DieSound;

    /// <summary>
    /// 나중에 슬라이더만 연결해주세요
    /// </summary>
    [Header("HP Bar")]
    public GameObject HPBar;

    Vector2 MoveToPosition;

    [SerializeField]
    //bool IsRightSprite;
    public enum State
    {
        Idle,
        Chase,
        Fight
    }
    public State _state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        _state = State.Chase;
        CanAttack = true;
        RandomPosition();
        HP = MaxHP;
        ChaseThing = GameObject.FindGameObjectWithTag("Player");
        //if (IsRightSprite)
        //{
        //    GetComponent<Transform>().localScale = new Vector2(-1, 1);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.GetComponent<Slider>().value = HP / MaxHP;
        switch (_state)
        {
            case State.Idle:
                MoveTo();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Fight:
                Fight();
                break;

            default:
                break;
        }
        //GetDamage(0.01f);
    }


    void Chase()
    {
        if (Vector2.Distance(transform.position, ChaseThing.transform.position) >= FightDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, ChaseThing.transform.position, Speed * 2.0f * Time.deltaTime);
        }
        else
        {
            _state = State.Fight;
        }

        if ((transform.position.x - ChaseThing.transform.position.x) >= 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Fight()
    {
        if (CanAttack)
        {
            Destroy(Instantiate(AttackPrefabs, transform.position, Quaternion.identity), 0.5f);
            CanAttack = false;
            StartCoroutine("AttackTimer");
        }
    }

    void MoveTo()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveToPosition, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MoveToPosition) == 0)
        {
            RandomPosition();
        }

        if ((transform.position.x - MoveToPosition.x) >= 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    void RandomPosition()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-10.0f, 10.0f);

        MoveToPosition = new Vector2(x, y); ;
    }

    public void GetDamage(float Damage)
    {
        Destroy(Instantiate(HitPrefabs),0.5f);
        HP -= Damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(AttackTime);
        _state = State.Chase;
        CanAttack = true;
    }
    void Die ()
    {
        Destroy(GetComponent<Collider2D>());
        Instantiate(Exps,transform.position,Quaternion.identity);
        AudioSource.PlayClipAtPoint(DieSound, transform.position);
        Destroy(gameObject, 0.5f);
    }
}
