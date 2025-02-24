using System.Collections;
using System.Collections.Generic;
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

    private Rigidbody2D rigidbody;

    public bool isDash { get; private set; }
    
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

            case PatternName.DASH:
                Debug.Log("dash");
                StartCoroutine(Windmill(from, to)); 
                break;
            case PatternName.WINDMILL:
                Debug.Log("windmill");
                StartCoroutine(Dash(from, to));
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
        if(rigidbody == null)
            rigidbody = GetComponentInParent<Rigidbody2D>();

        isDash = true;

        // ��� , ���
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 1 ,1.5f);
        yield return new WaitForSeconds(lineTime);

        // ����
        Vector2 targetPosition = to.position;
        Vector2 direction = (targetPosition - (Vector2)from.position).normalized;

        float timeLimit = 0;
        while(timeLimit <= 2f)
        {
            rigidbody.velocity = direction * 15f;
            if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
            {
                rigidbody.velocity = Vector2.zero;
            }

            timeLimit += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        rigidbody.velocity = Vector2.zero;
        isDash = false;
        yield return null;
    }
}
