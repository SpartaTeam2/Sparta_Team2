using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillHandler : MonoBehaviour
{
    private static SkillHandler instance;

    public static SkillHandler Instance { get {  return instance; } }

    public BasicSkills basicSkills;

    private Dictionary<int, SkillData> basicSkillDict;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        basicSkillDict = basicSkills.basicSkillDict;
    }

    private void Update()
    {
        Debug.Log(basicSkills.basicSkillDict[101].skillName);
    }
    public List<SkillData> RandomSkillDraw(int selection)
    {
        return basicSkills.basicSkillDict.Values.OrderBy(x => Random.Range(0, basicSkills.basicSkillDict.Count)).Take(selection).ToList();
    }

    public void ApplySkill(SkillData skillData)
    {
        switch (skillData.skillType)
        {
            case SkillType.AttackBoost:

                break;
            case SkillType.AttackSpeedBoost:

                break;
            case SkillType.CriticalBoost:

                break;
            case SkillType.HealthBoost:

                break;
            case SkillType.ProjectileUp:

                break;
        }
    }
}
