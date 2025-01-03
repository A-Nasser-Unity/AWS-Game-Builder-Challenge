using UnityEngine;
using System.Collections.Generic;

public class RandomSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 3f;
    [SerializeField] private float initialDelay = 0f;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null && audioClips.Count > 0)
        {
            Invoke("PlayRandomSound", initialDelay);
        }
    }

    private void PlayRandomSound()
    {
        if (audioClips.Count > 0 && audioSource != null)
        {
            // Get a random clip from the list
            int randomIndex = Random.Range(0, audioClips.Count);
            AudioClip randomClip = audioClips[randomIndex];

            // Play the random clip
            audioSource.clip = randomClip;
            audioSource.Play();

            // Schedule the next sound
            float nextDelay = Random.Range(minDelay, maxDelay);
            Invoke("PlayRandomSound", nextDelay);
        }
    }
}