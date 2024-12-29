using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement; // Required for scene management

public class OldPauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private string levelToLoad = "LevelName"; // Name of the level to load
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        // Check for Q press only when the game is paused
        if (isPaused && Input.GetKeyDown(KeyCode.Q))
        {
            LoadNewLevel();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    void LoadNewLevel()
    {
        // Reset time scale and audio before loading new level
        Time.timeScale = 1f;
        AudioListener.volume = 1f;

        // Load the specified level
        SceneManager.LoadScene(levelToLoad);
    }

    // Optional: Public method to set the level name at runtime
    public void SetLevelToLoad(string levelName)
    {
        levelToLoad = levelName;
    }
}
