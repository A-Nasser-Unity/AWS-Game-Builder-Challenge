using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float minWaitTime = 2f;
    [SerializeField] private float maxWaitTime = 5f;
    [SerializeField] private float childActiveTime = 3f;

    private AudioSource audioSource;
    private GameObject[] childObjects;
    private GameObject currentActiveChild;
    private float nextActivationTime;

    private void Start()
    {
        // Get all child objects and disable them initially
        childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            childObjects[i].SetActive(false);
        }

        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set initial activation time
        SetNextActivationTime();
    }

    private void Update()
    {
        if (Time.time >= nextActivationTime)
        {
            ActivateRandomChild();
        }
    }

    private void ActivateRandomChild()
    {
        // Deactivate current active child if there is one
        if (currentActiveChild != null)
        {
            currentActiveChild.SetActive(false);
        }

        // Select and activate a random child
        int randomIndex = Random.Range(0, childObjects.Length);
        currentActiveChild = childObjects[randomIndex];
        currentActiveChild.SetActive(true);

        // Play random audio clip
        if (audioClips != null && audioClips.Length > 0)
        {
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(randomClip);
        }

        // Schedule deactivation
        Invoke("DeactivateCurrentChild", childActiveTime);

        // Set next activation time
        SetNextActivationTime();
    }

    private void DeactivateCurrentChild()
    {
        if (currentActiveChild != null)
        {
            currentActiveChild.SetActive(false);
            currentActiveChild = null;
        }
    }

    private void SetNextActivationTime()
    {
        nextActivationTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }
}