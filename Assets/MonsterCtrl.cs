using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    [Header("몬스터 기본 스탯")]
    public float MaxHP;
    public float Speed;
    public float ChaseDis;
    public float FightDis;

    [Header("몬스터 현재 전투 정보")]
    public GameObject ChaseThing;
    public float HP;
    public float AttackTime;
    bool CanAttack;

    [Header("몬스터 공격 효과")]
    public GameObject AttackPrefabs;

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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        _state = State.Chase;
    //        ChaseThing = collision.gameObject;
    //    }
    //}

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
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(AttackTime);
        _state = State.Chase;
        CanAttack = true;
    }
}
