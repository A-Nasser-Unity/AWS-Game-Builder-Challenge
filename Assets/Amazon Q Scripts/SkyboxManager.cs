using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField]
    private Material[] skyboxMaterials; // Array to store skybox materials

    void Start()
    {
        // Check if we have any skybox materials assigned
        if (skyboxMaterials != null && skyboxMaterials.Length > 0)
        {
            // Get a random index
            int randomIndex = Random.Range(0, skyboxMaterials.Length);

            // Set the random skybox as the current one
            RenderSettings.skybox = skyboxMaterials[randomIndex];
        }
        else
        {
            Debug.LogWarning("No skybox materials assigned to SkyboxManager!");
        }
    }
}