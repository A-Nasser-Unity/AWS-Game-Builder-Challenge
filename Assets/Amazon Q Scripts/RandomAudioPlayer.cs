using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private float minTimeBetweenClips = 10f;
    [SerializeField] private float maxTimeBetweenClips = 20f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
            return;
        }

        if (audioClips.Count == 0)
        {
            Debug.LogWarning("No audio clips assigned to the list!");
            return;
        }

        StartCoroutine(PlayRandomAudioRoutine());
    }

    private IEnumerator PlayRandomAudioRoutine()
    {
        while (true)
        {
            // Wait for a random time between minTimeBetweenClips and maxTimeBetweenClips
            float waitTime = Random.Range(minTimeBetweenClips, maxTimeBetweenClips);
            yield return new WaitForSeconds(waitTime);

            // Select a random audio clip
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Count)];

            // Play the selected clip
            audioSource.clip = randomClip;
            audioSource.Play();

            // Wait for the clip to finish playing before continuing the loop
            yield return new WaitForSeconds(randomClip.length);
        }
    }
}
