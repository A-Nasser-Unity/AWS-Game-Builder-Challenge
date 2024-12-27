using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Reference to the UI panel
    [SerializeField] private string nextLevelName; // Name of the level to load when Q is pressed

    private bool isPaused = false;

    void Update()
    {
        // Check for P key press
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle pause state
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // Check for Q key press while paused
        if (isPaused && Input.GetKeyDown(KeyCode.Q))
        {
            LoadNextLevel();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze time
        AudioListener.volume = 0f; // Mute all audio
        pausePanel.SetActive(true); // Show pause menu
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume normal time
        AudioListener.volume = 1f; // Restore audio
        pausePanel.SetActive(false); // Hide pause menu
    }

    void LoadNextLevel()
    {
        ResumeGame(); // Make sure to restore time and audio before changing scenes
        SceneManager.LoadScene(nextLevelName);
    }
}