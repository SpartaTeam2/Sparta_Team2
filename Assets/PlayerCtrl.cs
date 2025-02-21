using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float MaxHp;
    public float HP;

    public float speed = 10.0f; //스피드
    public GameObject BulletPrefab; // 투사체
    public Transform GunPoint; // 발사 위치
    public float GunRate = 10f; //  발사 시간
    private float GunTimer; // 발사 타이머

    private Animator animator; // 애니메이터

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // 애니매이터 컴포넌트
        HP = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축 이동
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축 이동
        this.transform.Translate(new Vector2(xMove, yMove));  //이동

        if (xMove != 0|| yMove!=0)
        {
            animator.SetBool("Player_Walk", true);
            if (xMove > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            if (xMove <0)
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
        
        GunTimer += Time.deltaTime;
        if (GunTimer >= GunRate)
        {
            GunTimer = 0f;
            GunAtClosestMonster();
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
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
        // 씬에서 가장 가까운 적 찾기
        GameObject closestEnemy = FindClosestMonster();
        if (closestEnemy == null) return; // 적이 없으면 종료
                                          // 투사체 생성            
        GameObject Bullet = Instantiate(BulletPrefab, GunPoint.position, Quaternion.identity);

        // Rigidbody2D 가져오기            
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D가 없농");
            return;
        }

        // 투사체가 적을 향해 날아가도록 설정            
        Vector2 direction = (closestEnemy.transform.position - GunPoint.position).normalized;
        rb.velocity = direction * 10f; // 투사체 속도
    }

    public  void GetDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}