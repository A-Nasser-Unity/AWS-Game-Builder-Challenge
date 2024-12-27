using UnityEngine;

public class AnimatorAudioController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private int runStateHash;

    void Start()
    {
        // Get references to the Animator and AudioSource
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Cache the hash of the "Run" state for efficiency
        runStateHash = Animator.StringToHash("Base Layer.Run"); // Adjust "Base Layer" and "Run" to your Animator setup
    }

    void Update()
    {
        // Check if the current state is "Run"
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == runStateHash)
        {
            // Play audio if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop audio if playing
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
