using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCard : MonoBehaviour
{
    public SkillData selectedSkillData;

    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillDescription;

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

        skillCardBackGround.transform.position += new Vector3(-110 * (cardtotal - 1) + (220 * locatecard), 0, 0);
    }

    public void OnClickSelect()
    {
        SkillHandler.Instance.ApplyBasicSkills.ApplySkill(selectedSkillData);
    }

    public void GetSelectedSkill(SkillData data)
    {
        selectedSkillData = data;
        skillName.text = data.skillName;
        skillDescription.text = data.skillDescription;
    }
}
