using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBasicSkills : MonoBehaviour
{
    [SerializeField] public PlayerCtrl player;

    [SerializeField] private BasicSkills skill;

    [SerializeField] private int projectileLimit = 3;
    [SerializeField] private int wideProjectileLimit = 2;

    public void RemoveSkillFromRandom(int skillID)
    {
        if(skillID > 300)
            skill.legendSkillDict[skillID].SetActive(false);
        else if(skillID > 200)
            skill.epicSkillDict[skillID].SetActive(false);
        else
            skill.basicSkillDict[skillID].SetActive(false);
    }

    public void ApplySkill(SkillData skillData)
    {
        switch (skillData.skillType)
        {
            case SkillType.AttackBoost:
                player.AttackDamage *= (1 + skillData.skillValue);
                break;
            case SkillType.AttackSpeedBoost:
                player.GunRate *= (1 - skillData.skillValue);
                break;
            case SkillType.CriticalMaster:
                player.CritChance += skillData.skillValue * 100;
                if (player.CritChance >= 100)
                    RemoveSkillFromRandom(skillData.skillId);
                break;
            case SkillType.CriticalBoost:
                player.CritDamage += skillData.skillValue;
                break;
            case SkillType.HealthBoost:
                player.MaxHp *= (1 + skillData.skillValue);
                break;
            case SkillType.ProjectileUp:
                switch (skillData.skillId)
                {
                    case 106:
                        player.IsBackShot = true;
                        RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 107:
                        player.IsSideShot = true;
                        RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 206:
                        player.BulletCount++;
                        player.AttackDamage *= (1 - skillData.skillValue);
                        projectileLimit--;
                        if (projectileLimit == 0)
                            RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 207:
                        player.IsWideShot = true;
                        player.WideCount++;
                        wideProjectileLimit--;
                        if (wideProjectileLimit == 0)
                            RemoveSkillFromRandom(skillData.skillId);
                        break;
                }
                break;
        }
    }
}
