using UnityEngine;
using UnityEngine.UI;

public class CornCollectionSystem : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image progressFillImage;
    [SerializeField] private GameObject completionPanel;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip collectionSound;
    [SerializeField] private AudioClip completionSound;

    [Header("Progress Settings")]
    [SerializeField] private float progressIncrement = 0.1f;

    private AudioSource playerAudioSource;
    private float currentFillAmount = 0f;

    private void Start()
    {
        // Get the AudioSource component from the player
        playerAudioSource = GetComponent<AudioSource>();
        if (playerAudioSource == null)
        {
            Debug.LogError("AudioSource component not found on the player!");
        }

        // Ensure completion panel is hidden at start
        if (completionPanel != null)
        {
            completionPanel.SetActive(false);
        }

        // Initialize progress bar
        if (progressFillImage != null)
        {
            progressFillImage.fillAmount = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "Corn"
        if (other.CompareTag("Corn"))
        {
            CollectCorn();
            Destroy(other.gameObject);
        }
    }

    private void CollectCorn()
    {
        // Play collection sound
        if (collectionSound != null && playerAudioSource != null)
        {
            playerAudioSource.PlayOneShot(collectionSound);
        }

        // Update progress
        currentFillAmount += progressIncrement;

        // Update UI fill image
        if (progressFillImage != null)
        {
            progressFillImage.fillAmount = currentFillAmount;
        }

        // Check if collection is complete
        if (currentFillAmount >= 1f)
        {
            HandleCompletion();
        }
    }

    private void HandleCompletion()
    {
        // Play completion sound
        if (completionSound != null && playerAudioSource != null)
        {
            playerAudioSource.PlayOneShot(completionSound);
        }

        // Show completion panel
        if (completionPanel != null)
        {
            completionPanel.SetActive(true);
        }

        // Pause the game
        Time.timeScale = 0f;

        // Reset progress (for potential reuse)
        ResetProgress();
    }

    public void ResetProgress()
    {
        currentFillAmount = 0f;
        if (progressFillImage != null)
        {
            progressFillImage.fillAmount = 0f;
        }
    }

    // Call this method to resume the game (e.g., from a UI button)
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (completionPanel != null)
        {
            completionPanel.SetActive(false);
        }
    }
}
