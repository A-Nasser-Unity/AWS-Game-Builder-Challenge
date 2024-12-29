using UnityEngine;

public class OldSkyboxManager : MonoBehaviour
{
    // Array to store different skybox materials
    [SerializeField]
    private Material[] skyboxes;

    // Current skybox index
    private int currentSkyboxIndex = 0;

    // Option to start with a random skybox
    [SerializeField]
    private bool startWithRandomSkybox = true;

    void Start()
    {
        // Ensure we have skyboxes assigned
        if (skyboxes.Length > 0)
        {
            if (startWithRandomSkybox)
            {
                SetRandomSkybox();
            }
            else
            {
                SetSkybox(0);
            }
        }
        else
        {
            Debug.LogWarning("No skyboxes assigned to the SkyboxManager!");
        }
    }

    // Method to set a specific skybox by index
    public void SetSkybox(int index)
    {
        if (index >= 0 && index < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[index];
            currentSkyboxIndex = index;
        }
        else
        {
            Debug.LogWarning("Invalid skybox index!");
        }
    }

    // Method to set a random skybox
    public void SetRandomSkybox()
    {
        if (skyboxes.Length > 0)
        {
            int randomIndex = Random.Range(0, skyboxes.Length);
            SetSkybox(randomIndex);
        }
    }

    // Method to cycle to the next skybox
    public void NextSkybox()
    {
        int nextIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
        SetSkybox(nextIndex);
    }

    // Method to cycle to the previous skybox
    public void PreviousSkybox()
    {
        int previousIndex = (currentSkyboxIndex - 1 + skyboxes.Length) % skyboxes.Length;
        SetSkybox(previousIndex);
    }

    // Method to get the current skybox index
    public int GetCurrentSkyboxIndex()
    {
        return currentSkyboxIndex;
    }
}
