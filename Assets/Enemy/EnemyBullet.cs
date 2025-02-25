using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    public float Damage;

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PlayerCtrl>().GetDamage(Damage);
                break;

            case "Wall":
                Destroy(gameObject);
                break;
            default:
                Debug.Log("�̰� ��ĳ �����");
                break;
        }
        // �÷��̾� �浹

        // *�浹 ���̾� �����ϱ�
        // �Ѿ˳��� �浹 / ���� �浹 ( �浹 X )
    }


    public void Shot(Vector2 velocity, bool isRandom = false)
    {
        float bulletSpeed = 5;
        if (isRandom)
            bulletSpeed = Random.Range(2f, 7f);
        rigidbody.velocity = velocity * bulletSpeed;
    }
}
