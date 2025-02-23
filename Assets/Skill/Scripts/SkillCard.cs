using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillCard : MonoBehaviour
{
    public SkillData selectedSkillData;

    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillDescription;

    private void Start()
    {   
        
    }

    public void GetSelectedSkill(SkillData data)
    {
        selectedSkillData = data;
        skillName.text = data.skillName;
        skillDescription.text = data.skillDescription;
    }
}
