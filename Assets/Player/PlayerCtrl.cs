using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCtrl : MonoBehaviour
{
    [Header("플레이어 기본 스탯")]
    public float MaxHp;
    public float HP;
    public float speed = 10.0f; //스피드
    public float AttackDamage;

    [Header("플레이어 공격 정보")]
    public GameObject BulletPrefab; // 투사체
    public GameObject GUN; // 발사 위치
    public float GunRate = 10f; //  발사 시간
    private float GunTimer; // 발사 타이머

    [Header("플레이어 피격 정보")]
    public GameObject HitEffect;

    public AudioSource _audioSource;
    public AudioClip DieSoundClip;

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
                Debug.Log("The Input Value of xMove is 0");
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
            Vector2 newPos = closestEnemy.transform.position - transform.position;
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

    void fire()
    {
        Instantiate(BulletPrefab, GUN.transform.position, GUN.transform.rotation).GetComponent<BulletCtrl>().Attacker = gameObject;
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
        Destroy(Instantiate(HitEffect, transform.position, Quaternion.identity),0.5f);
    }
}