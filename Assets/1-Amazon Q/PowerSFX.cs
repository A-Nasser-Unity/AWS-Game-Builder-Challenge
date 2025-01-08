using UnityEngine;

public class PowerSFX : MonoBehaviour
{
    [SerializeField] private GameObject audioSourceObject; // Reference to the object with AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the referenced object
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
    }

    private void OnDisable()
    {
        // Play sound when the panel is deactivated
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}