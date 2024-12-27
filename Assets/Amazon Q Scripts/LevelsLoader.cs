using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsLoader : MonoBehaviour
{
    [SerializeField] private string levelName;  // You can set this in the Inspector
    [SerializeField] private Button loadButton; // Reference to the UI button

    private void Start()
    {
        // Verify button reference and add listener
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadLevel);
        }
        else
        {
            Debug.LogWarning("No button assigned to LevelLoader script!");
        }
    }

    public void LoadLevel()
    {
        // Check if the level name is set
        if (string.IsNullOrEmpty(levelName))
        {
            Debug.LogError("Level name is not set!");
            return;
        }

        // Check if the scene exists in build settings
        try
        {
            SceneManager.GetSceneByName(levelName);
            Debug.Log("Loading scene: " + levelName);
            SceneManager.LoadScene(levelName);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load scene '{levelName}'. Make sure it's added to Build Settings! Error: {e.Message}");
        }
    }

    // Optional: Method to set level name through code
    public void SetLevelName(string newLevelName)
    {
        levelName = newLevelName;
    }

    // Clean up when script is disabled or destroyed
    private void OnDisable()
    {
        if (loadButton != null)
        {
            loadButton.onClick.RemoveListener(LoadLevel);
        }
    }
}
