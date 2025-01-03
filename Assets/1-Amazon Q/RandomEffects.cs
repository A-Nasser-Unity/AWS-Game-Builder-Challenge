using UnityEngine;
using System.Collections.Generic;

public class RandomEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 3f;
    [SerializeField] private float initialDelay = 0f;
    [SerializeField] private float activeDuration = 2f;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null && audioClips.Count > 0 && transform.childCount > 0)
        {
            Invoke("ActivateRandomEffect", initialDelay);
        }
    }

    private void ActivateRandomEffect()
    {
        // Activate a random child
        int randomChildIndex = Random.Range(0, transform.childCount);
        Transform randomChild = transform.GetChild(randomChildIndex);
        randomChild.gameObject.SetActive(true);

        // Play a random audio clip
        if (audioClips.Count > 0 && audioSource != null)
        {
            int randomClipIndex = Random.Range(0, audioClips.Count);
            AudioClip randomClip = audioClips[randomClipIndex];
            audioSource.PlayOneShot(randomClip);
        }

        // Schedule deactivation
        Invoke("DeactivateEffect", activeDuration);

        // Schedule next activation
        float nextDelay = Random.Range(minDelay, maxDelay);
        Invoke("ActivateRandomEffect", nextDelay + activeDuration);
    }

    private void DeactivateEffect()
    {
        // Deactivate all child objects
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}