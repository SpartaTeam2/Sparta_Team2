using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkills : MonoBehaviour
{
    public Dictionary<int, SkillData> basicSkillDict = new Dictionary<int, SkillData>();


    private void Awake()
    {
        AddSkillsToDict();
    }

    //SkillData(int id, string name, string description, SkillType type, float value)
    //public enum SkillType
    //{
    //    AttackBoost,
    //    AttackSpeedBoost,
    //    CriticalBoost,
    //    HealthBoost,
    //    ProjectileUp,

    //}
    private void AddSkillsToDict()
    {
        basicSkillDict.Add(101, new SkillData(101, "���ݺν�Ʈ", "������ 30% ����", SkillType.AttackBoost, 0.3f));
        basicSkillDict.Add(102, new SkillData(102, "���ݺν�Ʈ(��)", "������ 15% ����", SkillType.AttackBoost, 0.15f));
        basicSkillDict.Add(103, new SkillData(103, "���ݼӵ� �ν�Ʈ", "���ݼӵ� 25% ����", SkillType.AttackSpeedBoost, 0.25f));
        basicSkillDict.Add(104, new SkillData(104, "���ݼӵ� �ν�Ʈ", "���ݼӵ� 12.5% ����", SkillType.AttackSpeedBoost, 0.125f));
        basicSkillDict.Add(105, new SkillData(105, "ũ��Ƽ�� ������", "ũ��Ƽ�� ������ 40%, ũ��Ƽ�� Ȯ�� 10% ����", SkillType.CriticalBoost, 0.4f));
        basicSkillDict.Add(106, new SkillData(106, "ũ��Ƽ�� ������(��)", "ũ��Ƽ�� ������ 20%, ũ��Ƽ�� Ȯ�� 5% ����", SkillType.CriticalBoost, 0.2f));
        basicSkillDict.Add(107, new SkillData(107, "HP �ν�Ʈ", "�ִ� ü���� 20% ����", SkillType.HealthBoost, 0.2f));
        basicSkillDict.Add(108, new SkillData(108, "��Ƽ��", "����ü 1�� ����, ���ݼӵ� 15% ������ 10% �϶�", SkillType.ProjectileUp, 1));

    }
}
