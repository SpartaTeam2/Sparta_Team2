using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        // �� �浹

        // �÷��̾� �浹

        // *�浹 ���̾� �����ϱ�
        // �Ѿ˳��� �浹 / ���� �浹 ( �浹 X )
    }

    public void Shot(Vector2 velocity)
    {
        rigidbody.velocity = velocity * 5;
    }
}
