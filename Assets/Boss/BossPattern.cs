using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public IEnumerator TestPattern_1(Transform from, Transform to)
    {
        // Ÿ���� �����ϴ� ����
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to);

        // ���� ���ӽð���ŭ ���
        yield return new WaitForSeconds(lineTime);

        // ���� �߻� ����
        Vector2 direction = (to.position - from.position).normalized;

        // �Ѿ� ����
        BossBullet bullet = Instantiate(bulletPrefab).GetComponent<BossBullet>();
        bullet.transform.position = transform.position;

        // �Ѿ� �̵�
        bullet.Shot(direction);
    }

    public void TestPattern_2()
    {

    }

    public void TestPattern_3()
    {

    }
}
