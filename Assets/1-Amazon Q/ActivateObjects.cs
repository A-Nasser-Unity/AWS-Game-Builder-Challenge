using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateObjects : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToControl = new List<GameObject>();

    [SerializeField]
    private float deactivationDuration = 3f;

    private void Start()
    {
        StartCoroutine(DeactivateAndActivateObjects());
    }

    private IEnumerator DeactivateAndActivateObjects()
    {
        // Deactivate all objects
        foreach (GameObject obj in objectsToControl)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Wait for specified duration
        yield return new WaitForSeconds(deactivationDuration);

        // Activate all objects
        foreach (GameObject obj in objectsToControl)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}