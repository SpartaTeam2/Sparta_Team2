using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardSprite : MonoBehaviour
{
    public List<Sprite> skillCardSprite;

    private SkillData selectedSkillData;

    private Image skillCardImage;

    private void Start()
    {
        skillCardImage = GetComponent<Image>();
        selectedSkillData = GetComponentInParent<SkillData>();
        SetSprite();
    }

    private void Update()
    {
        
    }

    private void SetSprite()
    {
        int type = (int)selectedSkillData.skillType;
        skillCardImage.sprite = skillCardSprite[type];
    }

}
