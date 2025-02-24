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
                        //�Ĺ� ����ü �߰�
                        break;
                    case 107:
                        //�¿� ����ü �߰�
                        break;
                    case 206:
                        //���� ����ü �߰�
                        break;
                }
                Debug.Log("projectile");
                break;
        }
    }

}
