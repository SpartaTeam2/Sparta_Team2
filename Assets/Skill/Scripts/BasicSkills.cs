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
        basicSkillDict.Add(101, new SkillData(101, "���ݺν�Ʈ", "���ݷ� : + 10%", SkillType.AttackBoost, 0.1f));
        basicSkillDict.Add(102, new SkillData(102, "���ݼӵ� �ν�Ʈ", "���ݼӵ� : + 10%", SkillType.AttackSpeedBoost, 0.1f));
        basicSkillDict.Add(103, new SkillData(103, "ũ��Ƽ�� ������", "ũ��Ƽ�� Ȯ�� : + 10%", SkillType.CriticalMaster, 0.1f));
        basicSkillDict.Add(104, new SkillData(104, "ũ��Ƽ�� �ν�Ʈ", "ũ��Ƽ�� ������ : + 15%", SkillType.CriticalBoost, 0.15f));
        basicSkillDict.Add(105, new SkillData(105, "HP �ν�Ʈ", "�ִ� ü�� : + 10%", SkillType.HealthBoost, 0.1f));
        basicSkillDict.Add(106, new SkillData(106, "�鼦", "�Ĺ� ����ü �߰�", SkillType.ProjectileUp, 1));
        basicSkillDict.Add(107, new SkillData(107, "���̵弦", "�¿� ����ü �߰�", SkillType.ProjectileUp, 1));


        epicSkillDict.Add(201, new SkillData(201, "���ݺν�Ʈ", "���ݷ� : + 20%", SkillType.AttackBoost, 0.2f));
        epicSkillDict.Add(202, new SkillData(202, "���ݼӵ� �ν�Ʈ", "���ݼӵ� : + 20%", SkillType.AttackSpeedBoost, 0.2f));
        epicSkillDict.Add(203, new SkillData(203, "ũ��Ƽ�� ������", "ũ��Ƽ�� Ȯ�� : + 20%", SkillType.CriticalMaster, 0.2f));
        epicSkillDict.Add(204, new SkillData(204, "ũ��Ƽ�� �ν�Ʈ", "ũ��Ƽ�� ������ : + 30%", SkillType.CriticalBoost, 0.3f));
        epicSkillDict.Add(205, new SkillData(205, "HP �ν�Ʈ", "�ִ� ü�� : + 20%", SkillType.HealthBoost, 0.2f));
        epicSkillDict.Add(206, new SkillData(206, "��Ƽ��", "����ü 1�� ����, ������ 10% �϶�", SkillType.ProjectileUp, 0.1f));
        epicSkillDict.Add(207, new SkillData(207, "���̵弦", "�缱 ����ü �߰�", SkillType.ProjectileUp, 1));


        legendSkillDict.Add(301, new SkillData(301, "���ݺν�Ʈ", "���ݷ� : + 30%", SkillType.AttackBoost, 0.3f));
        legendSkillDict.Add(302, new SkillData(302, "���ݼӵ� �ν�Ʈ", "���ݼӵ� : + 30%", SkillType.AttackSpeedBoost, 0.3f));
        legendSkillDict.Add(303, new SkillData(303, "ũ��Ƽ�� ������", "ũ��Ƽ�� Ȯ�� : + 30%", SkillType.CriticalMaster, 0.3f));
        legendSkillDict.Add(304, new SkillData(304, "ũ��Ƽ�� �ν�Ʈ", "ũ��Ƽ�� ������ : + 45%", SkillType.CriticalBoost, 0.45f));
        legendSkillDict.Add(305, new SkillData(305, "HP �ν�Ʈ", "�ִ� ü�� : + 30%", SkillType.HealthBoost, 0.3f));
    }
}
