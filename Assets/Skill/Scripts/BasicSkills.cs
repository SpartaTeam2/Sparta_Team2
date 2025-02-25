using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkills : MonoBehaviour
{
    public Dictionary<int, SkillData> basicSkillDict = new Dictionary<int, SkillData>();
    public Dictionary<int, SkillData> epicSkillDict = new Dictionary<int, SkillData>();
    public Dictionary<int, SkillData> legendSkillDict = new Dictionary<int, SkillData>();


    private void Awake()
    {
        AddSkillsToDict();
    }

    //SkillData(int id, string name, string description, SkillType type, float value)
    //public enum SkillType
    //{
    //    AttackBoost,
    //    AttackSpeedBoost,
    //    CriticalMaster,
    //    HealthBoost,
    //    ProjectileUp,

    //}
    private void AddSkillsToDict()
    {
        basicSkillDict.Add(101, new SkillData(101, "공격부스트", "공격력 : + 10%", SkillType.AttackBoost, 0.1f));
        basicSkillDict.Add(102, new SkillData(102, "공격속도 부스트", "공격속도 : + 10%", SkillType.AttackSpeedBoost, 0.1f));
        basicSkillDict.Add(103, new SkillData(103, "크리티컬 마스터", "크리티컬 확률 : + 10%", SkillType.CriticalMaster, 0.1f));
        basicSkillDict.Add(104, new SkillData(104, "크리티컬 부스트", "크리티컬 데미지 : + 15%", SkillType.CriticalBoost, 0.15f));
        basicSkillDict.Add(105, new SkillData(105, "HP 부스트", "최대 체력 : + 10%", SkillType.HealthBoost, 0.1f));
        basicSkillDict.Add(106, new SkillData(106, "백샷", "후방 투사체 추가", SkillType.ProjectileUp, 1));
        basicSkillDict.Add(107, new SkillData(107, "사이드샷", "좌우 투사체 추가", SkillType.ProjectileUp, 1));


        epicSkillDict.Add(201, new SkillData(201, "공격부스트", "공격력 : + 20%", SkillType.AttackBoost, 0.2f));
        epicSkillDict.Add(202, new SkillData(202, "공격속도 부스트", "공격속도 : + 20%", SkillType.AttackSpeedBoost, 0.2f));
        epicSkillDict.Add(203, new SkillData(203, "크리티컬 마스터", "크리티컬 확률 : + 20%", SkillType.CriticalMaster, 0.2f));
        epicSkillDict.Add(204, new SkillData(204, "크리티컬 부스트", "크리티컬 데미지 : + 30%", SkillType.CriticalBoost, 0.3f));
        epicSkillDict.Add(205, new SkillData(205, "HP 부스트", "최대 체력 : + 20%", SkillType.HealthBoost, 0.2f));
        epicSkillDict.Add(206, new SkillData(206, "멀티샷", "투사체 1개 증가, 데미지 10% 하락", SkillType.ProjectileUp, 0.1f));
        epicSkillDict.Add(207, new SkillData(207, "와이드샷", "사선 투사체 추가", SkillType.ProjectileUp, 1));


        legendSkillDict.Add(301, new SkillData(301, "공격부스트", "공격력 : + 30%", SkillType.AttackBoost, 0.3f));
        legendSkillDict.Add(302, new SkillData(302, "공격속도 부스트", "공격속도 : + 30%", SkillType.AttackSpeedBoost, 0.3f));
        legendSkillDict.Add(303, new SkillData(303, "크리티컬 마스터", "크리티컬 확률 : + 30%", SkillType.CriticalMaster, 0.3f));
        legendSkillDict.Add(304, new SkillData(304, "크리티컬 부스트", "크리티컬 데미지 : + 45%", SkillType.CriticalBoost, 0.45f));
        legendSkillDict.Add(305, new SkillData(305, "HP 부스트", "최대 체력 : + 30%", SkillType.HealthBoost, 0.3f));
    }
}
