using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for level loading
using System.Collections; // Add this to use IEnumerator

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [Header("UI Elements")]
    [SerializeField] private Image healthBarFill;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Effects")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private GameObject hurtEffectPrefab;

    [Header("Level Transition")]
    [SerializeField] private float timeBeforeLevelChange = 3f; // Time in seconds before level change
    [SerializeField] private string nextLevelName = "NextLevel"; // Name of the next level to load

    private ChickenController chickenController;
    private bool isDead = false;

    private void Start()
    {
        // Initialize health and UI
        currentHealth = maxHealth;
        chickenController = GetComponent<ChickenController>();
        UpdateHealthUI();

        // Make sure game over panel is hidden at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        // Reduce health
        currentHealth -= damageAmount;

        // Clamp health between 0 and max health
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // Play hurt effects
        PlayHurtEffects();

        // Update the UI
        UpdateHealthUI();

        // Check if player died
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void PlayHurtEffects()
    {
        // Play hurt sound if an audio file is assigned
        if (hurtSound != null)
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        }

        // Spawn hurt effect prefab if assigned
        if (hurtEffectPrefab != null)
        {
            Instantiate(hurtEffectPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("HurtEffectPrefab is not assigned!");
        }
    }

    public void Heal(float healAmount)
    {
        if (isDead) return;

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        isDead = true;

        // Show game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Call Die method on ChickenController
        if (chickenController != null)
        {
            chickenController.Die();
        }

        // Start the level transition after the delay
        StartCoroutine(LevelTransitionCoroutine());
    }

    private IEnumerator LevelTransitionCoroutine()
    {
        // Wait for the specified amount of time before loading the next level
        yield return new WaitForSeconds(timeBeforeLevelChange);

        // Load the next level by name
        SceneManager.LoadScene(nextLevelName);
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }

    public void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        UpdateHealthUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
}
