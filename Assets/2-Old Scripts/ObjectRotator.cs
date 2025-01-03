using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField, Tooltip("Set the rotation speed in degrees per second for each axis (X, Y, Z)")]
    private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);

    void Update()
    {
        // Rotate the object based on the rotation speed for each axis
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}