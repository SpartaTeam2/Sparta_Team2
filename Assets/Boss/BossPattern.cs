using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    public void TestPattern_1(Transform from, Transform to)
    {
        BossBullet bullet = Instantiate(bulletPrefab, transform).GetComponent<BossBullet>();

        Vector2 direction = (to.position - from.position).normalized;
        bullet.Shot(direction);
    }

    public void TestPattern_2()
    {

    }

    public void TestPattern_3()
    {

    }
}
