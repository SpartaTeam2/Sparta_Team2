using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardSprite : MonoBehaviour
{
    public List<Sprite> skillCardSprite;

    private Image skillCardImage;

    private void Start()
    {
        skillCardImage = GetComponent<Image>();
    }

}
