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

    private Button selectButton;
    [SerializeField] private Image skillCardBackGround;

    private void Start()
    {   
        selectButton = GetComponentInChildren<Button>();
    }

    // ��ų ī�� ��ġ ����
    public void CardLocation()
    {
        int locatecard = SkillHandler.Instance.selectedSkillNum;
        int cardtotal = SkillHandler.Instance.randomSkillNum;

        skillCardBackGround.transform.position += new Vector3(-220 * (cardtotal - 1) + (440 * locatecard), 0, 0);
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
