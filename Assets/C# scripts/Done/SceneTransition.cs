using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class AutoFadeSceneTransition : MonoBehaviour
{
    [Header("Fade Settings")]
    public Image fadeImage;        // Reference to the UI Image used for fading
    public float fadeDuration = 2f; // Duration of the fade

    [Header("Scene Settings")]
    public string nextSceneName;  // Name of the scene to load after fade-out

    private void Start()
    {
        // Start the fade-out and scene transition
        StartCoroutine(FadeOutAndLoad(nextSceneName));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        float elapsedTime = 0f;

        // Ensure the fadeImage is visible
        fadeImage.gameObject.SetActive(true);

        // Gradually increase the alpha of the fadeImage to 1
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}
