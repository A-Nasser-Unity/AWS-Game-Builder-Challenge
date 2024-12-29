using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField]
    private float minDelay = 1f;

    [SerializeField]
    private float maxDelay = 5f;

    [SerializeField]
    private float initialDelay = 0f;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        StartCoroutine(PlayRandomSounds());
    }

    private IEnumerator PlayRandomSounds()
    {
        // Wait for the initial delay before starting to play sounds
        if (initialDelay > 0)
        {
            yield return new WaitForSeconds(initialDelay);
        }

        while (true)
        {
            if (audioClips.Count > 0)
            {
                // Get a random clip from the list
                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Count)];

                // Play the clip
                audioSource.clip = randomClip;
                audioSource.Play();

                // Wait for a random delay between min and max values
                float randomDelay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(randomDelay);
            }
            else
            {
                Debug.LogWarning("No audio clips assigned to RandomSoundPlayer!");
                yield return new WaitForSeconds(1f);
            }
        }
    }
}