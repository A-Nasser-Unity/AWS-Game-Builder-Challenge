using UnityEngine;

public class AudioSourceToggle : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;    // The GameObject to monitor
    [SerializeField] private AudioSource audioSource;    // Reference to the AudioSource component

    private void Start()
    {
        // Ensure we have references to both components
        if (targetObject == null)
        {
            Debug.LogWarning("Target GameObject not assigned in AudioSourceToggle script!");
        }
        if (audioSource == null)
        {
            // Try to get the AudioSource from this GameObject if not assigned
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource component found!");
                enabled = false;  // Disable this script if no AudioSource is found
                return;
            }
        }
    }

    private void Update()
    {
        if (targetObject != null && audioSource != null)
        {
            // Toggle AudioSource based on target object's active state
            audioSource.enabled = !targetObject.activeSelf;
        }
    }
}