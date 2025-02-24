using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillHandler : MonoBehaviour
{
    public GameObject skillCardPrefab;

    private static SkillHandler instance;

    public static SkillHandler Instance { get {  return instance; } }

    public BasicSkills basicSkills;

    private Dictionary<int, SkillData> basicSkillDict;

    public List<SkillData> selectedSkillList;


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
        //GetRandomSkill(2); test code
    }

    private void Update()
    {

    }

    public void CreateSkillCard(SkillData listedSkill)
    {
        GameObject card = Instantiate(skillCardPrefab);
        SkillCard cardData = card.GetComponent<SkillCard>();
        cardData.GetSelectedSkill(listedSkill);
    }

    public void GetRandomSkill(int select)
    {
        selectedSkillList = RandomSkillDraw(select);

        foreach(SkillData skill in selectedSkillList)
        {
            CreateSkillCard(skill);
        }
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
