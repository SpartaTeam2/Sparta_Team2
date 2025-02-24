using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardSprite : MonoBehaviour
{
    public List<Sprite> skillCardSprite;

    private SkillCard selectedSkillCard;
    private SkillData selectedSkillSprite;

    private Image skillCardImage;

    private void Start()
    {
        skillCardImage = GetComponent<Image>();
        selectedSkillCard = GetComponentInParent<SkillCard>();
        selectedSkillSprite = selectedSkillCard.selectedSkillData;
        SetSprite();
    }

    private void Update()
    {
        
    }

    private void SetSprite()
    {
        int type = (int)selectedSkillSprite.skillType;
        skillCardImage.sprite = skillCardSprite[type];
    }

}
