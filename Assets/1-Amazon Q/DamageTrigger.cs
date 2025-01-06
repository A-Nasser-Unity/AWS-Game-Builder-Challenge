using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private GameObject hitEffectPrefab;
    [SerializeField] private AudioClip hitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get player health component
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Deal damage to player
                playerHealth.TakeDamage(damageAmount);

                // Spawn hit effect
                if (hitEffectPrefab != null)
                {
                    Instantiate(hitEffectPrefab, other.transform.position, Quaternion.identity);
                }

                // Play hit sound
                if (hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
                }

                // Destroy the object after effects are complete
                Destroy(gameObject);
            }
        }
    }
}