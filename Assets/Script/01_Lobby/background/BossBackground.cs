using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackground : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer bossSpriteRenderer;

    private int currentIndex;

    private const float fadeTime = 3f;
    private const float displayTime = 3f;

    private void Start()
    {
        bossSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        currentIndex = 1;

        animator.SetTrigger($"Boss{currentIndex++}");
        StartCoroutine(ChangeBackground());
    }

    private IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return StartCoroutine(FadeOut());

            animator.SetTrigger($"Boss{currentIndex++}");
            if (currentIndex >= 5)
                currentIndex = 1;

            yield return StartCoroutine(FadeIn());

            yield return new WaitForSeconds(displayTime);
        }
    }

    private IEnumerator FadeOut()
    {
        Color color = bossSpriteRenderer.color;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
            bossSpriteRenderer.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        bossSpriteRenderer.color = new Color(color.r, color.g, color.b, 0f);
    }
    private IEnumerator FadeIn()
    {
        Color color = bossSpriteRenderer.color;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeTime);
            bossSpriteRenderer.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        bossSpriteRenderer.color = new Color(color.r, color.g, color.b, 1f);
    }
}
