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
        // 벽 충돌

        // 플레이어 충돌

        // *충돌 레이어 설정하기
        // 총알끼리 충돌 / 몬스터 충돌 ( 충돌 X )
    }

    public void Shot(Vector2 velocity)
    {
        rigidbody.velocity = velocity * 5;
    }
}
