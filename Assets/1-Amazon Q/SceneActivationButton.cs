using UnityEngine;

public class SceneActivationButton : MonoBehaviour
{
    [SerializeField] private AsyncSceneLoader asyncSceneLoader; // Reference to the AsyncSceneLoader script

    // Method to be called when the button is pressed
    public void OnButtonPress()
    {
        if (asyncSceneLoader != null)
        {
            asyncSceneLoader.ActivateLoadedScene();
        }
        else
        {
            Debug.LogError("AsyncSceneLoader reference is not set!");
        }
    }
}
