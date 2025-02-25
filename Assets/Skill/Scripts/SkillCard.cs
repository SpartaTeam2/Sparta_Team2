using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCard : MonoBehaviour
{
    public SkillData selectedSkillData;

    public Text skillName;
    public Text skillDescription;

    private int selectedIndex;

    private Button selectButton;
    [SerializeField] private Image skillCardBackGround;

    private void Start()
    {   
        selectButton = GetComponentInChildren<Button>();
    }

    // 스킬 카드 위치 선정
    public void CardLocation()
    {
        int locatecard = SkillHandler.Instance.selectedSkillNum;
        int cardtotal = SkillHandler.Instance.randomSkillNum;

        skillCardBackGround.transform.position += new Vector3(-220 * (cardtotal - 1) + (440 * locatecard), 0, 0);
    }

    public void OnClickSelect()
    {
        SkillHandler.Instance.ApplyBasicSkills.ApplySkill(selectedSkillData);

        SkillHandler.Instance.DestroyCard();
    }

    public void GetSelectedSkill(SkillData data)
    {
        selectedIndex = SkillHandler.Instance.selectedSkillNum;
        selectedSkillData = data;
        skillName.text = data.skillName;
        skillDescription.text = data.skillDescription;

    }


}
