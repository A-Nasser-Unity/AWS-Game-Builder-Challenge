using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour
{
    public List<AudioClip> soundClips; // List of audio clips to play
    public float minTime = 1f;         // Minimum random time interval
    public float maxTime = 5f;         // Maximum random time interval

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (soundClips == null || soundClips.Count == 0)
        {
            Debug.LogError("No sound clips assigned to the RandomSoundPlayer script on " + gameObject.name);
            return;
        }

        StartCoroutine(PlayRandomSounds());
    }

    private IEnumerator PlayRandomSounds()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime); // Generate a random wait time
            yield return new WaitForSeconds(waitTime);

            AudioClip clip = soundClips[Random.Range(0, soundClips.Count)]; // Pick a random sound clip
            audioSource.PlayOneShot(clip); // Play the selected sound clip
        }
    }
}
