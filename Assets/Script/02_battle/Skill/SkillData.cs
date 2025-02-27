using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AttackBoost = 0, //���ݷ� ����
    AttackSpeedBoost = 1, //���ݼӵ� ����
    CriticalMaster = 2, //ġȮ ����
    CriticalBoost = 3, //ġ�� ����
    HealthBoost = 4, //ü�� ����
    ProjectileUp =5, //����ü ����
}
public class SkillData
{
    public int skillId;
    public string skillName;
    public string skillDescription;
    public SkillType skillType;
    public float skillValue;
    public bool canPick;

    public SkillData(int id, string name, string description, SkillType type, float value1, bool pick)
    {
        skillId = id;
        skillName = name;
        skillDescription = description;
        skillType = type;
        skillValue = value1;
        canPick = pick;
    }

    public void SetActive(bool active)
    {
        canPick = active;
    }
}
