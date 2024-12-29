using UnityEngine;
using System.Collections;

public class OldRandomChildAndAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips; // Array of audio clips
    [SerializeField] private float minWaitTime = 5f; // Minimum wait time between activations
    [SerializeField] private float maxWaitTime = 15f; // Maximum wait time between activations
    [SerializeField] private float initialDelay = 2f; // Delay before the first activation
    [SerializeField] private float childActiveTime = 3f; // Time each child stays active

    private AudioSource audioSource;
    private Transform[] children;
    private Transform currentActiveChild;
    private bool isRunning = false;

    void Start()
    {
        // Get the audio source component
        audioSource = GetComponent<AudioSource>();

        // Store all children in an array
        int childCount = transform.childCount;
        children = new Transform[childCount];

        // Populate the children array and ensure all children are initially deactivated
        for (int i = 0; i < childCount; i++)
        {
            children[i] = transform.GetChild(i);
            children[i].gameObject.SetActive(false);
        }

        // Start the coroutine with initial delay
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // Start the main loop coroutine
        isRunning = true;
        StartCoroutine(ActivateRandomChildAndPlay());
    }

    IEnumerator ActivateRandomChildAndPlay()
    {
        while (isRunning)
        {
            // Select and activate random child
            int randomChildIndex = Random.Range(0, children.Length);
            currentActiveChild = children[randomChildIndex];
            currentActiveChild.gameObject.SetActive(true);

            // Play random audio clip
            if (audioClips.Length > 0)
            {
                int randomClipIndex = Random.Range(0, audioClips.Length);
                audioSource.clip = audioClips[randomClipIndex];
                audioSource.Play();
            }

            // Start the deactivation coroutine
            StartCoroutine(DeactivateAfterDelay(currentActiveChild));

            // Wait for random time before next activation
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator DeactivateAfterDelay(Transform childToDeactivate)
    {
        yield return new WaitForSeconds(childActiveTime);
        if (childToDeactivate != null)
        {
            childToDeactivate.gameObject.SetActive(false);
        }
    }

    // Optional: Method to manually start the sequence with a custom delay
    public void StartSequenceWithDelay(float delay)
    {
        StopAllCoroutines();
        isRunning = false;

        // Ensure all children are deactivated
        foreach (Transform child in children)
        {
            if (child != null)
            {
                child.gameObject.SetActive(false);
            }
        }

        initialDelay = delay;
        StartCoroutine(DelayedStart());
    }

    // Optional: Method to stop the sequence
    public void StopSequence()
    {
        isRunning = false;
        StopAllCoroutines();

        // Deactivate current child if any
        if (currentActiveChild != null)
        {
            currentActiveChild.gameObject.SetActive(false);
        }
    }

    // Optional: Method to change the active time during runtime
    public void SetChildActiveTime(float newActiveTime)
    {
        childActiveTime = newActiveTime;
    }
}
