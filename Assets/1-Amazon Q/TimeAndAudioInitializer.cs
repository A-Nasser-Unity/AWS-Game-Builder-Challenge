using UnityEngine;

public class TimeAndAudioInitializer : MonoBehaviour
{
    void Start()
    {
        // Reset time scale to normal speed
        Time.timeScale = 1f;

        // Reset audio volume to full
        AudioListener.volume = 1f;
    }
}