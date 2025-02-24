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

    public int randomSkillNum = 0;
    public int selectedSkillNum = 0;

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
        //GetRandomSkill(3); //test code
    }

    private void Update()
    {

    }

    //프리팹 스킬 카드 생성
    public void CreateSkillCard(List<SkillData> selectedSkillList)
    {
        foreach (SkillData skill in selectedSkillList)
        {
            GameObject card = Instantiate(skillCardPrefab);
            SkillCard cardData = card.GetComponent<SkillCard>();
            cardData.GetSelectedSkill(skill);
            cardData.CardLocation();
            selectedSkillNum++;
        }
        selectedSkillNum = 0;
        randomSkillNum = 0;
    }

    public void GetRandomSkill(int select)
    {
        List<SkillData> selectedSkillList = RandomSkillDraw(select);
        randomSkillNum = select;

        CreateSkillCard(selectedSkillList);
    }

    // 스킬 목록에서 랜덤 선택(중복제외)
    public List<SkillData> RandomSkillDraw(int selection)
    {
        return basicSkillDict.Values.OrderBy(x => Random.Range(0, basicSkillDict.Count)).Take(selection).ToList();
    }

    public void ApplySkill(SkillData skillData)
    {
        switch (skillData.skillType)
        {
            case SkillType.AttackBoost:
                Debug.Log("attack");
                break;
            case SkillType.AttackSpeedBoost:
                Debug.Log("attackspeed");
                break;
            case SkillType.CriticalBoost:
                Debug.Log("crit");
                break;
            case SkillType.HealthBoost:
                Debug.Log("health");
                break;
            case SkillType.ProjectileUp:
                Debug.Log("projectile");
                break;
        }
    }
}
