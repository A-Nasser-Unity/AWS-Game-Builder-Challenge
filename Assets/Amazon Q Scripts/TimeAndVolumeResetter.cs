using UnityEngine;

public class TimeAndVolumeResetter : MonoBehaviour
{
    public void ResetTimeAndVolume()
    {
        // Set time scale back to normal (1)
        Time.timeScale = 1f;

        // Set global audio volume to full (1)
        AudioListener.volume = 1f;
    }

    // Optional: You can call this from Start() if you want it to happen 
    // automatically when the script is enabled
    private void Start()
    {
        ResetTimeAndVolume();
    }
}