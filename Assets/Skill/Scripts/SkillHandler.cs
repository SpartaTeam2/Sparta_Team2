using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillHandler : MonoBehaviour
{
    public GameObject skillCardPrefab;

    public ApplyBasicSkills ApplyBasicSkills;
    private static SkillHandler instance;

    public static SkillHandler Instance { get {  return instance; } }

    public BasicSkills basicSkills;

    public Dictionary<int, SkillData> basicSkillDict;
    public Dictionary<int, SkillData> epicSkillDict;
    public Dictionary<int, SkillData> legendSkillDict;

    public List<GameObject> cardObjectList;

    public int randomSkillNum = 0;
    public int selectedSkillNum = 0;
    public float destroyDelayTime;
    public int applySkillNum = 0;

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
        epicSkillDict = basicSkills.epicSkillDict;
        legendSkillDict = basicSkills.legendSkillDict;

        RandomRarity(3); //test code
    }

    public void DestroyCard()
    {
        foreach(GameObject card in cardObjectList)
        {
            SkillCardUI skillUI = card.GetComponentInChildren<SkillCardUI>();
            if (cardObjectList.IndexOf(card) == applySkillNum)
            {
                //가운데로 이동 애니메이션
                skillUI.Selected();
            }
            else
            {
                //파괴 애니메이션
                skillUI.Destroy();
            }

        }
        //이후 파괴
        StartCoroutine(DestroyObject());
        cardObjectList.Clear();
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyDelayTime);
        
        foreach (GameObject card in cardObjectList)
        {
            Destroy(card);
        }
    }

    //프리팹 스킬 카드 생성
    public void CreateSkillCard(List<SkillData> selectedSkillList)
    {
        foreach (SkillData skill in selectedSkillList)
        {
            GameObject card = Instantiate(skillCardPrefab);
            cardObjectList.Add(card);
            SkillCard cardData = card.GetComponent<SkillCard>();
            cardData.GetSelectedSkill(skill);
            cardData.CardLocation();
            selectedSkillNum++;
        }
        selectedSkillNum = 0;
        randomSkillNum = 0;
    }

    public void GetRandomSkill(int basic, int epic, int legend)
    {
        List<SkillData> selectedBasicSkillList = BasicSkillDraw(basic);
        List<SkillData> selectedEpicSkillList = EpicSkillDraw(epic);
        List<SkillData> selectedLegendSkillList = LegendSkillDraw(legend);

        List<SkillData> selectedSkillList = selectedBasicSkillList.Concat(selectedEpicSkillList.Concat(selectedLegendSkillList))
                                            .OrderBy(x => Random.Range(0,basic+epic+legend)).ToList();

        randomSkillNum = basic + epic + legend;

        CreateSkillCard(selectedSkillList);
    }

    public void RandomRarity(int select)
    {
        int basic = 0;
        int epic = 0;
        int legend = 0;

        for(int i = 0; i < select; i++)
        {
            int kindOfRare = RandomRareSet();
            switch(kindOfRare)
            {
                case 1: legend++; break;
                case 2: epic++; break;
                case 3: basic++; break;
            }
        }

        GetRandomSkill(basic, epic, legend);
    }

    public int RandomRareSet()
    {
        int[] percentage = { 2, 10, 88 }; //레전더리,에픽,노말 확률

        int totalper = 0;
        foreach (int i in percentage) // 배열 숫자 바꿔서 확률 변동 가능
        {
            totalper += i;
        }

        int random = Random.Range(0, totalper);

        int kindOfRare = random < percentage[0] ? 1 : random < percentage[1] ? 2 : 3;

        return kindOfRare;
    }

    // 스킬 목록에서 랜덤 선택(중복제외)
    public List<SkillData> BasicSkillDraw(int selection)
    {
        return basicSkillDict.Values.OrderBy(x => Random.Range(0, basicSkillDict.Count)).Take(selection).ToList();
    }
    public List<SkillData> EpicSkillDraw(int selection)
    {
        return epicSkillDict.Values.OrderBy(x => Random.Range(0, epicSkillDict.Count)).Take(selection).ToList();
    }
    public List<SkillData> LegendSkillDraw(int selection)
    {
        return legendSkillDict.Values.OrderBy(x => Random.Range(0, legendSkillDict.Count)).Take(selection).ToList();
    }

    public void ResetRandomDict()
    {
        foreach (KeyValuePair<int, SkillData> skills in basicSkillDict)
        {
            skills.Value.SetActive(true);
        }
        foreach (KeyValuePair<int, SkillData> skills in epicSkillDict)
        {
            skills.Value.SetActive(true);
        }
        foreach (KeyValuePair<int, SkillData> skills in legendSkillDict)
        {
            skills.Value.SetActive(true);
        }
    }


}
