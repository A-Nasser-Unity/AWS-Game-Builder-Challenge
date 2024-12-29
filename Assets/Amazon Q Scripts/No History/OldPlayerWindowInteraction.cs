using UnityEngine;

public class OldPlayerWindowInteraction : MonoBehaviour
{
    [SerializeField] private ParticleSystem breakEffect; // Assign your particle prefab in inspector
    [SerializeField] private AudioClip breakSound; // Assign your audio clip in inspector
    [SerializeField] private float particleSpawnOffset = 1f; // Distance to spawn particles from the window

    private AudioSource playerAudio;
    private CharacterController characterController;

    private void Start()
    {
        // Get the required components
        playerAudio = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();

        if (playerAudio == null)
        {
            Debug.LogWarning("No AudioSource found on player. Please add an AudioSource component.");
        }

        if (characterController == null)
        {
            Debug.LogWarning("No CharacterController found on player. Please add a CharacterController component.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Window"))
        {
            // Get the direction the player is facing
            Vector3 playerDirection = transform.forward;

            // Calculate spawn position
            // This will spawn the particles slightly in front of the window in the player's direction
            Vector3 windowPosition = other.transform.position;
            Vector3 particlePosition = windowPosition + (playerDirection * particleSpawnOffset);

            // Spawn particles and rotate them to face the direction of impact
            if (breakEffect != null)
            {
                // Calculate rotation to face the player's direction
                Quaternion particleRotation = Quaternion.LookRotation(playerDirection);

                // Instantiate the particle system
                ParticleSystem particles = Instantiate(breakEffect, particlePosition, particleRotation);

                // Optional: Adjust particle system's shape/emission based on player direction
                var mainModule = particles.main;
                var emissionModule = particles.emission;

                // Optional: You might want to modify particle properties here
                // For example, you could adjust the direction or spread

                // Destroy the particle system after it finishes
                Destroy(particles.gameObject, mainModule.duration);
            }

            // Play sound on player
            if (playerAudio != null && breakSound != null)
            {
                playerAudio.PlayOneShot(breakSound);
            }

            // Destroy the window
            Destroy(other.gameObject);
        }
    }

    // Optional: Visual debug to see the direction in Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * particleSpawnOffset);
    }
}
