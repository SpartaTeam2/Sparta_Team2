using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternName
{
    TEST,
    BURST
}

public class BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private Rigidbody2D rigidbody;

    public bool isDash { get; private set; }

    private void Start()
    {
        isDash = false;
    }

    public void OnPattern(Transform from, Transform to, PatternName pattern)
    {
        switch(pattern)
        {
            case PatternName.TEST:
                Debug.Log("test");
                StartCoroutine(TestPattern(from, to));
                break;

            case PatternName.BURST:
                Debug.Log("burst");
                StartCoroutine(ShootBurst(from, to));
                break;
        }
    }

    private IEnumerator TestPattern(Transform from, Transform to)
    {
        // 타겟을 추적하는 라인
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

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

    // 플레이어를 향해 bulletcount만큼 발사 
    private IEnumerator ShootBurst(Transform from, Transform to)
    {
        int bulletcount = Random.Range(5, 15);

        // 타겟을 추적하는 라인
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

        for (int i = 0; i < bulletcount; i++)
        {
            // 라인 지속시간 / 총알 발사 수 만큼 대기
            yield return new WaitForSeconds(lineTime / bulletcount);

            // 총알 방향
            Vector2 direction = (to.position - from.position).normalized;

            // 총알 생성
            BossBullet bullet = Instantiate(bulletPrefab).GetComponent<BossBullet>();
            bullet.transform.position = transform.position;

            // 총알 이동
            bullet.Shot(direction);
        }
    }
}
