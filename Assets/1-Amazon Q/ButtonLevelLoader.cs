using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLevelLoader : MonoBehaviour
{
    [SerializeField] private string levelName; // Level name to load
    private Button button;

    private void Awake()
    {
        // Get the Button component
        button = GetComponent<Button>();

        // Add click listener
        if (button != null)
        {
            button.onClick.AddListener(LoadLevel);
        }
    }

    private void LoadLevel()
    {
        // Load the specified level
        if (!string.IsNullOrEmpty(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("Level name not specified on " + gameObject.name);
        }
    }

    private void OnDestroy()
    {
        // Remove the click listener when the object is destroyed
        if (button != null)
        {
            button.onClick.RemoveListener(LoadLevel);
        }
    }
}