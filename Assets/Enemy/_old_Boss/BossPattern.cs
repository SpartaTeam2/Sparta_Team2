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
        // Ÿ���� �����ϴ� ����
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

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
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.1f);

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
}
