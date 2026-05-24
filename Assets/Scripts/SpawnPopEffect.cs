using UnityEngine;
using System.Collections;

public class SpawnPopEffect : MonoBehaviour
{
    public float duration = 0.35f;
    public float startScale = 0.05f;

    private Vector3 originalScale;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void PlaySpawn()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        transform.localScale = originalScale * startScale;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            // Smooth pop animation
            float eased = Mathf.Sin(t * Mathf.PI * 0.5f);

            transform.localScale = Vector3.Lerp(
                originalScale * startScale,
                originalScale,
                eased
            );

            yield return null;
        }

        transform.localScale = originalScale;
    }
}