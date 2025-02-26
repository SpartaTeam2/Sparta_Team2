using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int maxHP;            // 최대체력
    public int damage;           // 공격력
    public float moveSpeed;      // 이동 속도
    public float attackDelay;    // 공격 딜레이

    public float trackingRange;  // 추격 범위
    public float attackRange;    // 공격 범위
}
