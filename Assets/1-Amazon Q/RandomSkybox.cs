using UnityEngine;
using System.Collections;

public class RandomSkybox : MonoBehaviour
{
    // Array to hold the skybox materials
    public Material[] skyboxMaterials;

    // Delay before changing skybox (in seconds)
    public float changeDelay = 0f;

    void Start()
    {
        StartCoroutine(ChangeSkyboxWithDelay());
    }

    IEnumerator ChangeSkyboxWithDelay()
    {
        // Wait for the specified delay
        if (changeDelay > 0)
        {
            yield return new WaitForSeconds(changeDelay);
        }

        // Check if we have any skybox materials assigned
        if (skyboxMaterials != null && skyboxMaterials.Length > 0)
        {
            // Get a random index
            int randomIndex = Random.Range(0, skyboxMaterials.Length);

            // Set the random skybox as the active skybox
            RenderSettings.skybox = skyboxMaterials[randomIndex];
        }
        else
        {
            Debug.LogWarning("No skybox materials assigned to RandomSkybox script!");
        }
    }
}