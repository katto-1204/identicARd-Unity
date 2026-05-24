using UnityEngine;
using Vuforia;

public class ARTargetController : MonoBehaviour
{
    public GameObject arContent;
    public AudioSource voiceMessage;
    public SpawnPopEffect spawnEffect;
    public ParticleSystem spawnParticles;
    public UIFadeInEffect uiFadeEffect;

    private ObserverBehaviour observer;
    private bool hasPlayed = false;

    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (arContent != null)
        {
            arContent.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        if (isTracked)
        {
            ShowARContent();
        }
        else
        {
            HideARContent();
        }
    }

    private void ShowARContent()
    {
        if (arContent != null)
        {
            arContent.SetActive(true);
        }

        if (spawnEffect != null)
        {
            spawnEffect.PlaySpawn();
        }

        if (spawnParticles != null)
        {
            spawnParticles.Stop();
            spawnParticles.Play();
        }

        if (uiFadeEffect != null)
        {
            uiFadeEffect.PlayFade();
        }

        if (voiceMessage != null && !hasPlayed)
        {
            voiceMessage.Play();
            hasPlayed = true;
        }
    }

    private void HideARContent()
    {
        if (arContent != null)
        {
            arContent.SetActive(false);
        }

        if (voiceMessage != null && voiceMessage.isPlaying)
        {
            voiceMessage.Stop();
        }
    }

    public void ReplayVoice()
    {
        if (voiceMessage != null)
        {
            voiceMessage.Stop();
            voiceMessage.Play();
        }
    }
}