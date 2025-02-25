using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int maxHP;            // �ִ�ü��
    public int damage;           // ���ݷ�
    public float moveSpeed;      // �̵� �ӵ�
    public float attackDelay;    // ���� ������

    public float trackingRange;  // �߰� ����
    public float attackRange;    // ���� ����
}
