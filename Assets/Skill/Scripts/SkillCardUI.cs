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
    private Button button;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponentInChildren<Button>();
        image = GetComponent<Image>();
        time = SkillHandler.Instance.destroyDelayTime / 2f;
        delayTime = time;
    }
    public void Selected()
    {
        button.interactable = false;
        Vector2 targetPosition = new Vector2(0, 0);
        rectTransform.DOAnchorPos(targetPosition, time).SetEase(Ease.OutCirc);

        StartCoroutine(DelayedDestroy());
    }

    public void Destroy()
    {
        button.interactable = false;
        Vector2 targetPosition = new Vector2(rectTransform.anchoredPosition.x, 1500);
        Color targetColor = new Color(image.color.r, image.color.b, image.color.g, 0);
        rectTransform.DOAnchorPos(targetPosition, time).SetEase(Ease.InCirc);
        image.DOColor(targetColor, 1f);
        skillImage.DOColor(targetColor, 1f);
        nameText.DOFade(0, 1f);
        descriptionText.DOFade(0, 1f);
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(delayTime);

        Destroy();
    }
}
