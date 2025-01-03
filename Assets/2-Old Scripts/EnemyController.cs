using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float followDistance = 10f;
    [SerializeField] private float damageAmount = 10f;

    private Transform player;
    private Vector3 startPosition;
    private bool isReturning = false;
    private bool isStopped = false;
    private PlayerHealth playerHealth;

    void Start()
    {
        // Save initial position
        startPosition = transform.position;

        // Find the player GameObject using tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Get reference to player health component
        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (player == null || isStopped) return;

        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Follow the player if within distance
        if (distanceToPlayer <= followDistance)
        {
            isReturning = false; // Cancel returning state if player re-enters the distance
            FollowPlayer();
        }
        // Return to start position if out of range
        else if (!isReturning)
        {
            StartCoroutine(ReturnToStart());
        }
    }

    private void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotate towards the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Move towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private IEnumerator ReturnToStart()
    {
        isReturning = true;

        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            if (Vector3.Distance(transform.position, player.position) <= followDistance)
            {
                // Cancel returning if the player re-enters follow distance
                isReturning = false;
                yield break;
            }

            Vector3 direction = (startPosition - transform.position).normalized;

            // Rotate towards the start position
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Move towards the start position
            transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // Snap to start position and reset state
        transform.position = startPosition;
        isReturning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerHealth != null)
        {
            // Damage the player
            playerHealth.TakeDamage(damageAmount);

            // Stop enemy for 3 seconds
            StartCoroutine(StopEnemy());
        }
    }

    private IEnumerator StopEnemy()
    {
        isStopped = true;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        isStopped = false;
    }
}
