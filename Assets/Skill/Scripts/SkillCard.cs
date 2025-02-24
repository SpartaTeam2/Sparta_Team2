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

    private void Start()
    {   
        selectButton = GetComponentInChildren<Button>();
    }

    public void OnClickSelect()
    {
        SkillHandler.Instance.ApplySkill(selectedSkillData);
    }

    public void GetSelectedSkill(SkillData data)
    {
        selectedSkillData = data;
        skillName.text = data.skillName;
        skillDescription.text = data.skillDescription;
    }
}
