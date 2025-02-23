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
        basicSkillDict.Add(101, new SkillData(101, "공격부스트", "데미지 30% 증가", SkillType.AttackBoost, 0.3f));
        basicSkillDict.Add(102, new SkillData(102, "공격부스트(소)", "데미지 15% 증가", SkillType.AttackBoost, 0.15f));
        basicSkillDict.Add(103, new SkillData(103, "공격속도 부스트", "공격속도 25% 증가", SkillType.AttackSpeedBoost, 0.25f));
        basicSkillDict.Add(104, new SkillData(104, "공격속도 부스트", "공격속도 12.5% 증가", SkillType.AttackSpeedBoost, 0.125f));
        basicSkillDict.Add(105, new SkillData(105, "크리티컬 마스터", "크리티컬 데미지 40%, 크리티컬 확률 10% 증가", SkillType.CriticalBoost, 0.4f));
        basicSkillDict.Add(106, new SkillData(106, "크리티컬 마스터(소)", "크리티컬 데미지 20%, 크리티컬 확률 5% 증가", SkillType.CriticalBoost, 0.2f));
        basicSkillDict.Add(107, new SkillData(107, "HP 부스트", "최대 체력을 20% 증가", SkillType.HealthBoost, 0.2f));
        basicSkillDict.Add(108, new SkillData(108, "멀티샷", "투사체 1개 증가, 공격속도 15% 데미지 10% 하락", SkillType.ProjectileUp, 1));

    }
}
