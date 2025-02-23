using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : MonoBehaviour
{
    public List<SkillData> selectedSkills;

    private void Start()
    {
    
    }

    private void GetSelectedSkillList()
    {
        selectedSkills = SkillHandler.Instance.selectedSkillList;
    }
}
