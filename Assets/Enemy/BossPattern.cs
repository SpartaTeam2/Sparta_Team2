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

        // 타겟을 추적하는 라인
        float lineTime = GuideLine.Instance.OnTrackingLine(from, to, 0.15f);

        // 대기
        yield return new WaitForSeconds(lineTime);

        for(int i = 0; i < bulletCount; i++)
        {
            // 대상이 사라지면 ( 플레이어 사망했을때 )
            if (to == null)
                break;

            // 발사 방향
            Vector2 direction = (to.position - from.position).normalized;

            // 총알 생성
            EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
            bullet.transform.position = transform.position;
            bullet.damage = owner.Damage;

            // 총알 이동
            bullet.Shot(direction);

            yield return new WaitForSeconds(0.15f);
        }

        ownerHandler?.EndAttack();
    }

    private IEnumerator RotationBurst(Transform from, Transform to)
    {
        float lineTime = 0f;

        Vector2 baseDirection = (to.position - from.position).normalized; // A → B 방향
        float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg; // 기준 각도
        // Atan2는 Vector2의 posotion 정보를 각도로 바꿔주는 역할
        // Rad2Deg 는 Rad를 각도로 변환하는 역할
        // Rad2Rad 는 각도를 Rad로 변환하는 역할

        // baseDirection은 발사위치에서 타겟위치의 방향 Vector
        // baseAngel은 baseDirection의 각도
        int attackCount = Random.Range(1, 4);
        for(int i = 0; i < attackCount; i++)
        {
            int bulletCount = Random.Range(8, 16);
            // 경고선 표시
            for (int j = 0; j < bulletCount; j++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * j);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = from.position + (Vector3)(dir * 10f);

                lineTime = GuideLine.Instance.OnTwoPointLine(
                    transform.position, targetPos, 0.15f, 0.5f);
            }
            // 대기
            yield return new WaitForSeconds(lineTime);

            // 공격
            for(int j = 0; j < bulletCount; j ++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * j);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = from.position + (Vector3)(dir * 10f);

                // 발사 방향
                Vector2 direction = (targetPos - from.position).normalized;

                // 총알 생성
                EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
                bullet.transform.position = transform.position;
                bullet.damage = owner.Damage;

                // 총알 이동
                bullet.Shot(direction);
            }
        }


        ownerHandler?.EndAttack();
    }

    private IEnumerator IdleBurst()
    {
        yield return null;
        float baseAngle = Mathf.Atan2(0, 1) * Mathf.Rad2Deg; // 기준 각도
        int bulletCount = Random.Range(8, 16);
        int ratationCount = Random.Range(2, 4);
        ownerHandler?.EndAttack();
        for (int c = 0; c < ratationCount; c++)
            for(int i = 0; i < bulletCount; i++)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, baseAngle + (360f / bulletCount) * i);
                Vector2 dir = rotation * Vector2.right;

                Vector3 targetPos = transform.position + (Vector3)(dir * 10f);

                // 발사 방향
                Vector2 direction = (targetPos - transform.position).normalized;

                // 총알 생성
                EnemyBullet bullet = Instantiate(bulletPrefab).GetComponent<EnemyBullet>();
                bullet.transform.position = transform.position;
                bullet.damage = owner.Damage;

                // 총알 이동
                bullet.Shot(direction);
                yield return new WaitForSeconds(0.1f);
            }
    }
}
