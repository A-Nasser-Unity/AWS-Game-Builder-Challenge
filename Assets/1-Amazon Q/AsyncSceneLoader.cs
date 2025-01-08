using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;  // Name of the scene to load

    private AsyncOperation asyncLoad;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Start loading the scene asynchronously in the background
        asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Don't let the scene activate until it's triggered manually
        asyncLoad.allowSceneActivation = false;

        // While the scene is loading
        while (!asyncLoad.isDone)
        {
            // Optionally, you can monitor the progress here
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");

            yield return null; // Wait until the next frame
        }
    }

    // Call this method to activate the loaded scene
    public void ActivateLoadedScene()
    {
        if (asyncLoad != null && asyncLoad.progress >= 0.9f)
        {
            Debug.Log("Activating scene...");
            asyncLoad.allowSceneActivation = true;
        }
        else
        {
            Debug.LogWarning("Scene is not ready to activate yet!");
        }
    }
}
