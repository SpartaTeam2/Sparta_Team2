using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBasicSkills : MonoBehaviour
{
    [SerializeField] private PlayerCtrl player;

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
                Debug.Log("attack");
                player.AttackDamage *= (1 + skillData.skillValue);
                break;
            case SkillType.AttackSpeedBoost:
                Debug.Log("attackspeed");
                player.GunRate *= (1 - skillData.skillValue);
                break;
            case SkillType.CriticalMaster:
                Debug.Log("critChance");
                player.CritChance += skillData.skillValue * 100;
                break;
            case SkillType.CriticalBoost:
                Debug.Log("crit");
                player.CritDamage += skillData.skillValue * 100;
                break;
            case SkillType.HealthBoost:
                Debug.Log("health");
                player.MaxHp *= (1 + skillData.skillValue);
                break;
            case SkillType.ProjectileUp:
                switch (skillData.skillId)
                {
                    case 106:
                        player.IsBackShot = true;
                        Debug.Log("back");
                        RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 107:
                        player.IsSideShot = true;
                        Debug.Log("side");
                        RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 206:
                        player.BulletCount++;
                        player.AttackDamage *= (1 - skillData.skillValue);
                        Debug.Log("double");
                        projectileLimit--;
                        if (projectileLimit == 0)
                            RemoveSkillFromRandom(skillData.skillId);
                        break;
                    case 207:
                        player.IsWideShot = true;
                        player.WideCount++;
                        Debug.Log("wide");
                        wideProjectileLimit--;
                        if (wideProjectileLimit == 0)
                            RemoveSkillFromRandom(skillData.skillId);
                        break;
                }
                break;
        }
    }
}
