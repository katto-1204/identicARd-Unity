using UnityEngine;
using System.Collections;

public class UIFadeInEffect : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 0.5f;

    void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void PlayFade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        canvasGroup.alpha = 0f;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}