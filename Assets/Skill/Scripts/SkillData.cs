using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AttackBoost = 0, //공격력 증가
    AttackSpeedBoost = 1, //공격속도 증가
    CriticalBoost = 2, //치명타 증가
    HealthBoost = 3, //체력 증가
    ProjectileUp = 4, //투사체 증가
}
public class SkillData
{
    public int skillId;
    public string skillName;
    public string skillDescription;
    public SkillType skillType;
    public float skillValue;

    public SkillData(int id, string name, string description, SkillType type, float value)
    {
        skillId = id;
        skillName = name;
        skillDescription = description;
        skillType = type;
        skillValue = value;
    }
}
