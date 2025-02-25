using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCtrl : MonoBehaviour
{
    [Header("플레이어 기본 스탯")]
    public float MaxHp;
    public float HP;
    public float speed = 10.0f; //스피드
    public float AttackDamage;

    [Header("플레이어 장비 정보")]
    //public 


    [Header("플레이어 공격 정보")]
    public GameObject BulletPrefab; // 투사체
    public GameObject GUN; // 발사 위치
    public float GunRate = 10f; //  발사 시간
    private float GunTimer; // 발사 타이머
    public float BulletSpace; //투사체 간극
    public int BulletCount = 1; //투사체 개수
    public bool IsSideShot = false; //측면샷 on/off
    public bool IsBackShot = false; //백샷 on/off
    public bool IsWideShot = false; //와이드샷 on/off
    public int WideCount = 0;
    public float CritChance = 0;
    public float CritDamage = 0;

    [Header("플레이어 피격 정보")]
    public GameObject HitEffect;

    public AudioSource _audioSource;
    public AudioClip DieSoundClip;

    Vector2 newPos;

    Animator animator; // 애니메이터

    // Start is called before the first frame update
    void Start()
    {
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>(); // 애니매이터 컴포넌트
        HP = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축 이동
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축 이동
        this.transform.Translate(new Vector2(xMove, yMove));  //이동

        if (xMove != 0 || yMove != 0)
        {
            animator.SetBool("Player_Walk", true);
            if (xMove > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            if (xMove < 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else
            {
                //Debug.Log("The Input Value of xMove is 0");
                Debug.Log(transform.position);
            }
        }
        else
        {
            animator.SetBool("Player_Walk", false);
        }
        GunAtClosestMonster();
    }

    void GunAtClosestMonster()
    {
        GameObject FindClosestMonster()
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            GameObject closestMonster = null;
            float shortestDistance = Mathf.Infinity;
            foreach (GameObject Monster in Monsters)
            {
                float distance = Vector3.Distance(transform.position, Monster.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestMonster = Monster;
                }
            }
            return closestMonster;
        }

        GameObject closestEnemy = FindClosestMonster();
        if (closestEnemy != null)
        {
            newPos = closestEnemy.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            GUN.transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (closestEnemy.transform.position.x - transform.position.x > 0)
            {
                GUN.GetComponent<SpriteRenderer>().flipY = false;
            }
            else
            {
                GUN.GetComponent<SpriteRenderer>().flipY = true;
            }
            GunTimer += Time.deltaTime;
            if (GunTimer >= GunRate)
            {
                GunTimer = 0f;
                fire();
            }
        }
        else
        {

        }
    }

    private void BackShot()
    {
        if (!IsBackShot)
            return;

        Vector3 newPos3 = new Vector3 (newPos.x, newPos.y, 0);
        Vector3 backShot = GUN.transform.position - (newPos3.normalized * 0.5f);
        float backZ = Mathf.Atan2(-newPos.y, -newPos.x) * Mathf.Rad2Deg;
        Quaternion backDirection = Quaternion.Euler(0, 0, backZ);

        Instantiate(BulletPrefab, backShot, backDirection).GetComponent<BulletCtrl>().Attacker = gameObject;
    }

    private void SideShot()
    {
        if (!IsSideShot)
            return;

        Vector3 newPos3 = new Vector3(newPos.x, newPos.y, 0);

        Vector3 sideShotLeft = new Vector3(transform.position.x - (newPos3.normalized.y * 0.25f), transform.position.y + (newPos3.normalized.x * 0.25f), 0);
        Vector3 sideShotRight = new Vector3(transform.position.x + (newPos3.normalized.y * 0.25f), transform.position.y - (newPos3.normalized.x * 0.25f), 0);

        float leftZ = Mathf.Atan2(-newPos.x, newPos.y) * Mathf.Rad2Deg;
        float rightZ = Mathf.Atan2(newPos.x, -newPos.y) * Mathf.Rad2Deg;

        Quaternion leftDirection = Quaternion.Euler(0, 0, leftZ);
        Quaternion rightDirection = Quaternion.Euler(0, 0, rightZ);

        Instantiate(BulletPrefab, sideShotLeft, leftDirection).GetComponent<BulletCtrl>().Attacker = gameObject;
        Instantiate(BulletPrefab, sideShotRight, rightDirection).GetComponent<BulletCtrl>().Attacker = gameObject;
    }

    private void WideShot()
    {
        if (!IsWideShot)
            return;

        Vector3 newPos3 = new Vector3(newPos.x, newPos.y, 0);

        if (WideCount > 0)
        {
            Quaternion deg30 = GUN.transform.rotation * Quaternion.Euler(0, 0, 30);
            Quaternion degm30 = GUN.transform.rotation * Quaternion.Euler(0, 0, -30);
            Instantiate(BulletPrefab, GUN.transform.position, deg30).GetComponent<BulletCtrl>().Attacker = gameObject;
            Instantiate(BulletPrefab, GUN.transform.position, degm30).GetComponent<BulletCtrl>().Attacker = gameObject;

            if(WideCount > 1)
            {
                Quaternion deg60 = GUN.transform.rotation * Quaternion.Euler(0, 0, 60);
                Quaternion degm60 = GUN.transform.rotation * Quaternion.Euler(0, 0, -60);
                Instantiate(BulletPrefab, GUN.transform.position, deg60).GetComponent<BulletCtrl>().Attacker = gameObject;
                Instantiate(BulletPrefab, GUN.transform.position, degm60).GetComponent<BulletCtrl>().Attacker = gameObject;
            }
        }


    }

    private void MultipleFire() //최대 투사체 4개, 중앙부터 대칭으로  -1.5 -0.5 0.5 1.5 의 위치
    {
        float bulletspace = BulletSpace / (BulletCount - 1); //투사체간 간극
        Vector3 newPos3 = new Vector3(newPos.x, newPos.y, 0);
        Vector3 verticalDirection = new Vector3(-newPos3.y, newPos3.x, 0); //원의 접선 방향 벡터값

        for (int i = 0; i < BulletCount; i++)
        {
            // 4개면 -1.5 -0.5 0.5 1.5   
            // 3개 -1.5 0 1.5            
            // 2개 -1.5 1.5               
            float location = (i - ((BulletCount - 1) / 2.0f)) * bulletspace;
            Vector3 multiplePosition = transform.position + (newPos3.normalized * 0.25f) + verticalDirection.normalized * location;

            Instantiate(BulletPrefab, multiplePosition, GUN.transform.rotation).GetComponent<BulletCtrl>().Attacker = gameObject;
        }
    }

    void fire()
    {
        BackShot();
        SideShot();
        WideShot();
        if (BulletCount == 1)
            Instantiate(BulletPrefab, GUN.transform.position, GUN.transform.rotation).GetComponent<BulletCtrl>().Attacker = gameObject;
        else if (BulletCount > 1)
            MultipleFire();
    }
    public void GetDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            AudioSource.PlayClipAtPoint(DieSoundClip, transform.position);
            Destroy(gameObject, 1.0f); //삭제처리 아니고 나중에 부활처리로 할겁니다요
            return;
        }
        Destroy(Instantiate(HitEffect, transform.position, Quaternion.identity), 0.5f);
    }
}