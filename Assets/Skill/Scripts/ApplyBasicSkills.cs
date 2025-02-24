using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBasicSkills : MonoBehaviour
{
    //[SerializeField] private GameObject player;

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
                        break;
                    case 107:
                        //좌우 투사체 추가
                        break;
                    case 206:
                        //전방 투사체 추가
                        break;
                }
                Debug.Log("projectile");
                break;
        }
    }

}
