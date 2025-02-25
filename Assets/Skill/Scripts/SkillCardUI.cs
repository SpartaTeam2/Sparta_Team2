using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SkillCardUI : MonoBehaviour
{
    public RectTransform rectTransform;
    public Image image;
    public Image skillImage;
    public Text nameText;
    public Text descriptionText;
    public float time;
    public float delayTime;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    public void Selected()
    {
        Vector2 targetPosition = new Vector2(0, 0);
        rectTransform.DOAnchorPos(targetPosition, time).SetEase(Ease.OutCirc);

        StartCoroutine(Delay());
    }

    public void Destroy()
    {
        Vector2 targetPosition = new Vector2(rectTransform.anchoredPosition.x, 1500);
        Color targetColor = new Color(image.color.r, image.color.b, image.color.g, 0);
        rectTransform.DOAnchorPos(targetPosition, time).SetEase(Ease.InCirc);
        image.DOColor(targetColor, 1f);
        skillImage.DOColor(targetColor, 1f);
        nameText.DOFade(0, 1f);
        descriptionText.DOFade(0, 1f);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);

        Destroy();
    }
}
