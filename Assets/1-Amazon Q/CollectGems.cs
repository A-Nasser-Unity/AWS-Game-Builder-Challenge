using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectGems : MonoBehaviour
{
    [SerializeField] private AudioClip gemCollectSound;
    [SerializeField] private TextMeshProUGUI gemCountText;
    private AudioSource audioSource;
    private int gemCount = 0;
    public string nextSceneName;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        UpdateGemText();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Gem"))
        {
            CollectGem(collision.gameObject);
        }
    }

    private void CollectGem(GameObject gem)
    {
        // Play sound
        if (gemCollectSound != null)
        {
            audioSource.PlayOneShot(gemCollectSound);
        }

        // Increment count and update UI
        gemCount++;
        UpdateGemText();

        // Destroy the gem
        Destroy(gem);

        // Check if we've collected enough gems
        if (gemCount >= 10)
        {
            LoadNextScene();
        }
    }

    private void UpdateGemText()
    {
        if (gemCountText != null)
        {
            gemCountText.text = gemCount.ToString();
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}