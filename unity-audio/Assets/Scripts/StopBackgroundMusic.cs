using UnityEngine;

public class StopBackgroundMusic : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioSource victoryAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }

            if (!victoryAudioSource.isPlaying)
            {
                victoryAudioSource.Play();
            }
        }
    }
}
