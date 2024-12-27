using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Public variables for customization in the Inspector
    public Vector3 rotationAxis = Vector3.up; // Default is rotation around the Y-axis
    public float rotationSpeed = 100f; // Default speed in degrees per second

    void Update()
    {
        // Rotate the object around the specified axis at the specified speed
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
