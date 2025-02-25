using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        // �� �浹

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
