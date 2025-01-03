using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
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
                    Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                }

                // Play sound effect
                if (hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
                }

                // Destroy this enemy
                Destroy(gameObject);
            }
        }
    }
}