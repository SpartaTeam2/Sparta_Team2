using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AttackBoost = 0, //공격력 증가
    AttackSpeedBoost = 1, //공격속도 증가
    CriticalMaster = 2, //치확 증가
    CriticalBoost = 3, //치피 증가
    HealthBoost = 4, //체력 증가
    ProjectileUp =5, //투사체 증가
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
