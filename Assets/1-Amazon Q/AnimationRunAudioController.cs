using UnityEngine;

public class AnimationRunAudioController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private bool isRunning = false;

    void Start()
    {
        // Get required components
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Validate components
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Check if the "Run" animation state is currently active
        bool currentlyRunning = animator.GetCurrentAnimatorStateInfo(0).IsName("Run");

        // If the running state changed, update audio accordingly
        if (currentlyRunning != isRunning)
        {
            isRunning = currentlyRunning;

            if (isRunning)
            {
                // Start playing audio when entering run state
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                // Stop audio when leaving run state
                audioSource.Stop();
            }
        }
    }
}