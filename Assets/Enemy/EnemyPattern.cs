using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PatternName
{
    Shoot,
    BURST
}

public class EnemyPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    public void OnPattern(Transform from, Transform to, PatternName pattern)
    {
        switch (pattern)
        {
            case PatternName.Shoot:
                StartCoroutine(Shot(from, to));
                break;
        }
    }

    private IEnumerator Shot(Transform from, Transform to)
    {
        // 타겟을 추적하는 라인
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

        // 라인 지속시간만큼 대기
        yield return new WaitForSeconds(lineTime);

        // 최종 발사 방향
        Vector2 direction = (to.position - from.position).normalized;

        // 총알 생성
        EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
        bullet.transform.position = transform.position;

        // 총알 이동
        bullet.Shot(direction);
    }
}
