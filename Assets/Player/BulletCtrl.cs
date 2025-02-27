using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [Header("총알 이미지 (Sprite)")]
    public Sprite BulletImage;

    [Header("총알 기본 스탯")]
    public float lifetime = 1.0f; // 투사체 유지 시간
    public float Damage;
    public float BulletSpeed;
    //public AudioSource _audioSource;
    //public AudioClip _bulletSound;

    public GameObject Attacker;
    public AudioClip _audioClip;

    // Start is called before the first frame update
    void Start()
    {
        if (BulletImage != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = BulletImage; //있으면 변경
        }
        //if (_audioSource == null)
        //    _audioSource = GetComponent<AudioSource>();
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
        if (collision.CompareTag(Attacker.tag)) // 태그가 같으면
        {
            // 아무것도 안하기
        }
        else
        {
            switch (collision.tag)
            {
                case "Player":

                    break;
                case "Monster":
                    float i = Random.Range(0, 100);
                    if (i<= Attacker.GetComponent<PlayerCtrl>().CritChance) //크리티컬 처리
                    {
                        collision.GetComponent<BaseEnemy>().GetDamage(Damage + (Damage * Attacker.GetComponent<PlayerCtrl>().CritDamage));
                        EffectManager.Instance?.PlayEffect(EffectType.ExplosionBlue, transform.position);
                    }
                    else //노크리 처리
                    {
                        collision.GetComponent<BaseEnemy>().GetDamage(Damage);
                        EffectManager.Instance?.PlayEffect(EffectType.ExplosionYellow, transform.position);
                    }

                    AudioManager.Instance.PlaySfx(_audioClip);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
