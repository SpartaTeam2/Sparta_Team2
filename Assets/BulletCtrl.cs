using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [Header("총알 이미지 (Sprite)")]
    public Sprite BulletImage;

    [Header("총알 기본 스탯")]
    public float lifetime = 1.0f; // 투사체 유지 시간
    public float Damage;
    public float BulletSpeed;

    public GameObject Attacker;

    // Start is called before the first frame update
    void Start()
    {
        Damage = Attacker.GetComponent<PlayerCtrl>().AttackDamage;
        Destroy(gameObject, lifetime); // 투사체 삭제
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * BulletSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Attacker.tag)) // If same gameobject
        {
            // do nothing
        }
        else
        {
            switch (collision.tag)
            {
                case "Player":

                    break;
                case "Monster":
                    collision.GetComponent<MonsterCtrl>().GetDamage(Damage);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
