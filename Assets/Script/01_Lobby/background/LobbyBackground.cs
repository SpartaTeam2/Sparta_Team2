using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBackground : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundSprites;
    private SpriteRenderer backgroundSprite;

    private int currentIndex;

    private const float fadeTime = 3f;
    private const float displayTime = 3f;

    private void Start()
    {
        backgroundSprite = GetComponent<SpriteRenderer>();

        currentIndex = 1;

        StartCoroutine(ChangeBackground());
    }

    private IEnumerator ChangeBackground()
    {
        while(true)
        {
            yield return StartCoroutine(FadeOut());

            backgroundSprite.sprite = backgroundSprites[currentIndex++];
            if (currentIndex >= backgroundSprites.Length)
                currentIndex = 0;

            yield return StartCoroutine(FadeIn());

            yield return new WaitForSeconds(displayTime);
        }
    }

    private IEnumerator FadeOut()
    {
        Color color = backgroundSprite.color;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
            backgroundSprite.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        backgroundSprite.color = new Color(color.r, color.g, color.b, 0f);
    }
    private IEnumerator FadeIn()
    {
        Color color = backgroundSprite.color;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeTime);
            backgroundSprite.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        backgroundSprite.color = new Color(color.r, color.g, color.b, 1f);
    }
}
