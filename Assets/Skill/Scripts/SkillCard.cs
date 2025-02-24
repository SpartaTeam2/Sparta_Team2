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

    public void CardLocation()
    {
        int num = SkillHandler.Instance.selectedSkillNum;
        switch (SkillHandler.Instance.randomSkillNum)
        {
            case 2:
                skillCardBackGround.transform.position += new Vector3(-110 + (220 * num), 0, 0);
                break;
            case 3:
                skillCardBackGround.transform.position += new Vector3(-220 + (220 * num), 0, 0);
                break;
        }
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
