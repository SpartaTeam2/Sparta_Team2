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
        // Ÿ���� �����ϴ� ����
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

        // ���� ���ӽð���ŭ ���
        yield return new WaitForSeconds(lineTime);

        // ���� �߻� ����
        Vector2 direction = (to.position - from.position).normalized;

        // �Ѿ� ����
        EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
        bullet.transform.position = transform.position;

        // �Ѿ� �̵�
        bullet.Shot(direction);
    }
}
