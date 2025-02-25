using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBasicSkills : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    [SerializeField] private BasicSkills skill;

    [SerializeField] private int projectileLimit = 3;
    [SerializeField] private int wideProjectileLimit = 2;

    public void RemoveSkillFromDict(int skillID)
    {
        if(skillID > 300)
            skill.legendSkillDict.Remove(skillID);
        else if(skillID > 200)
            skill.epicSkillDict.Remove(skillID);
        else
            skill.basicSkillDict.Remove(skillID);
    }
    public void ApplySkill(SkillData skillData)
    {
        switch (skillData.skillType)
        {
            case SkillType.AttackBoost:
                Debug.Log("attack");
                //player.AttackDamage *= (1 + skillData.skillValue);
                break;
            case SkillType.AttackSpeedBoost:
                Debug.Log("attackspeed");
                //player.GunRate *= (1 - skillData.skillValue);
                break;
            case SkillType.CriticalMaster:
                Debug.Log("critChance");
                //player.critChance += skillData.skillValue;
                break;
            case SkillType.CriticalBoost:
                Debug.Log("crit");
                //player.critDamage += skillData.skillValue;
                break;
            case SkillType.HealthBoost:
                Debug.Log("health");
                //player.MaxHp *= (1 + skillData.skillValue);
                break;
            case SkillType.ProjectileUp:
                switch (skillData.skillId)
                {
                    case 106:
                        //후방 투사체 추가
                        RemoveSkillFromDict(skillData.skillId);
                        break;
                    case 107:
                        //좌우 투사체 추가
                        RemoveSkillFromDict(skillData.skillId);
                        break;
                    case 206:
                        //전방 투사체 추가
                        //player.AttackDamage *= (1 - skillData.skillValue);
                        projectileLimit--;
                        if (projectileLimit == 0)
                            RemoveSkillFromDict(skillData.skillId);
                        break;
                    case 207:
                        //사선 투사체 추가
                        wideProjectileLimit--;
                        if (wideProjectileLimit == 0)
                            RemoveSkillFromDict(skillData.skillId);
                        break;
                }
                break;
        }
    }

}
