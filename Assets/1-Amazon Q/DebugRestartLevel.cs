using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugRestartLevel : MonoBehaviour
{
    [SerializeField]
    private float timeUntilRestart = 5f; // Default value of 5 seconds

    private float timer;

    private void Start()
    {
        timer = timeUntilRestart;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}