using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PatternName
{
    TEST,
    BURST,
    WINDMILL,
    DASH
}

public class BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    public void OnPattern(Transform from, Transform to, PatternName pattern)
    {
        switch(pattern)
        {
            case PatternName.TEST:
                StartCoroutine(TestPattern(from, to));
                break;

            case PatternName.BURST:
                StartCoroutine(ShootBurst(from, to));
                break;

            case PatternName.DASH:
                StartCoroutine(Windmill(from, to)); 
                break;
            case PatternName.WINDMILL:
                StartCoroutine(Dash(from, to));
                break;
        }
    }

    private IEnumerator TestPattern(Transform from, Transform to)
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

    // �÷��̾ ���� bulletcount��ŭ �߻� 
    private IEnumerator ShootBurst(Transform from, Transform to)
    {
        int bulletcount = Random.Range(5, 15);

        // Ÿ���� �����ϴ� ����
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to);

        for (int i = 0; i < bulletcount; i++)
        {
            // ���� ���ӽð� / �Ѿ� �߻� �� ��ŭ ���
            yield return new WaitForSeconds(lineTime / bulletcount);

            // �Ѿ� ����
            Vector2 direction = (to.position - from.position).normalized;

            // �Ѿ� ����
            BossBullet bullet = Instantiate(bulletPrefab).GetComponent<BossBullet>();
            bullet.transform.position = transform.position;

            // �Ѿ� �̵�
            bullet.Shot(direction);
        }
    }

    // ��� �������� ���
    private IEnumerator Windmill(Transform from, Transform to)
    {
        int shotcount = Random.Range(3, 7);
        int bulletCount = Random.Range(8, 32);

        yield return null;
    }

    // ����
    private IEnumerator Dash(Transform from, Transform to)
    {
        yield return null;
    }
}
