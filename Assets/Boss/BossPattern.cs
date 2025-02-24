using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    public IEnumerator TestPattern_1(Transform from, Transform to)
    {
        // 타겟을 추적하는 라인
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to);

        // 라인 지속시간만큼 대기
        yield return new WaitForSeconds(lineTime);

        // 최종 발사 방향
        Vector2 direction = (to.position - from.position).normalized;

        // 총알 생성
        BossBullet bullet = Instantiate(bulletPrefab).GetComponent<BossBullet>();
        bullet.transform.position = transform.position;

        // 총알 이동
        bullet.Shot(direction);
    }

    public void TestPattern_2()
    {

    }

    public void TestPattern_3()
    {

    }
}
