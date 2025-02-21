using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AttackBoost,
    AttackSpeedBoost,
    CriticalBoost,
    HealthBoost,
    ProjectileUp,
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
