using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    public float FullHP;
    public float HP;

    public float Speed;
    public float ChaseDis;

    public GameObject ChaseThing;
    public float FightDis;

    Vector2 MoveToPosition;

    public float AttackTime;
    bool CanAttack;

    public GameObject AttackPrefabs;
    public GameObject HPBar;

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
        CanAttack = true;
        RandomPosition();
        HP = FullHP;
        ChaseThing = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.GetComponent<Slider>().value = HP / FullHP;
        switch(_state)
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
        GetDamage(0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _state = State.Chase;
            ChaseThing = collision.gameObject;
        }
    }

    void RandomPosition ()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-10.0f, 10.0f);

        MoveToPosition = new Vector2(x, y); ;
    }

    void MoveTo()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveToPosition, Speed *Time.deltaTime);

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
            Instantiate(AttackPrefabs, transform.position, Quaternion.identity);
            CanAttack = false;
            StartCoroutine("AttackTimer");
        }
    }

    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    IEnumerator AttackTimer ()
    {
        yield return new WaitForSeconds(AttackTime);
        _state = State.Chase;
        CanAttack = true;
    }
}
