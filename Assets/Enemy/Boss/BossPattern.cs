using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PatternName
{
    BURST,
    ROTATION,
    IDLE,
}

public class BossPattern : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private BaseEnemy owner;
    private EnemyAttackHandler ownerHandler;

    public void InitPattern(EnemyAttackHandler ownerHandler, BaseEnemy owner)
    {
        this.ownerHandler = ownerHandler;
        this.owner = owner;
    }

    public void OnPattern(Transform from, Transform to, PatternName pattern)
    {
        switch (pattern)
        {
            case PatternName.BURST:
                StartCoroutine(Burst(from, to));
                break;

            case PatternName.ROTATION:
                StartCoroutine(RotationBurst(from, to));
                break;
            case PatternName.IDLE:
                StartCoroutine(IdleBurst());
                break;
        }
    }

    private IEnumerator Burst(Transform from, Transform to)
    {
        int bulletCount = Random.Range(7, 14);

        // Ÿ���� �����ϴ� ����
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.15f);

        // ���
        yield return new WaitForSeconds(lineTime);

        for(int i = 0; i < bulletCount; i++)
        {
            // ����� ������� ( �÷��̾� ��������� )
            if (to == null)
                break;

            // �߻� ����
            Vector2 direction = (to.position - from.position).normalized;

            // �Ѿ� ����
            EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
            bullet.transform.position = transform.position;
            bullet.damage = owner.Damage;

            // �Ѿ� �̵�
            bullet.Shot(direction);

            yield return new WaitForSeconds(0.15f);
        }

        ownerHandler?.EndAttack();
    }

    private IEnumerator RotationBurst(Transform from, Transform to)
    {
        float lineTime = 0f;

        Vector2 baseDirection = (to.position - from.position).normalized; // A �� B ����
        float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg; // ���� ����
        // Atan2�� Vector2�� posotion ������ ������ �ٲ��ִ� ����
        // Rad2Deg �� Rad�� ������ ��ȯ�ϴ� ����
        // Rad2Rad �� ������ Rad�� ��ȯ�ϴ� ����

        // baseDirection�� �߻���ġ���� Ÿ����ġ�� ���� Vector
        // baseAngel�� baseDirection�� ����
        int attackCount = Random.Range(1, 4);
        for(int i = 0; i < attackCount; i++)
        {
            int bulletCount = Random.Range(8, 16);
            // ��� ǥ��
            for (int j = 0; j < bulletCount; j++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * j);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = from.position + (Vector3)(dir * 10f);

                lineTime = GuideLine.Instance.OnTwoPointLine(
                    transform.position, targetPos, 0.15f, 0.5f);
            }
            // ���
            yield return new WaitForSeconds(lineTime);

            // ����
            for(int j = 0; j < bulletCount; j ++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * j);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = from.position + (Vector3)(dir * 10f);

                // �߻� ����
                Vector2 direction = (targetPos - from.position).normalized;

                // �Ѿ� ����
                EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
                bullet.transform.position = transform.position;
                bullet.damage = owner.Damage;

                // �Ѿ� �̵�
                bullet.Shot(direction);
            }
        }


        ownerHandler?.EndAttack();
    }

    private IEnumerator IdleBurst()
    {
        yield return null;
        float baseAngle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg; // ���� ����
        int bulletCount = Random.Range(8, 16);
        int ratationCount = Random.Range(2, 4);
        ownerHandler?.EndAttack();
        for (int c = 0; c < ratationCount; c++)
            for(int i = 0; i < bulletCount; i++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * i);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = transform.position + (Vector3)(dir * 10f);

                // �߻� ����
                Vector2 direction = (targetPos - transform.position).normalized;

                // �Ѿ� ����
                EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
                bullet.transform.position = transform.position;
                bullet.damage = owner.Damage;

                // �Ѿ� �̵�
                bullet.Shot(direction);
                yield return new WaitForSeconds(0.1f);
            }
    }
}
