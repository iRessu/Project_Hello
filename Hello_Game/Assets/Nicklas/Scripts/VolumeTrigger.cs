using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    //private float volumeOnEnter = 1f;
    private float volumeOnExit = 0f;

    private void Awake()
    {
        volumeOnExit = 0f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            float playerPrefsVolume = PlayerPrefs.GetFloat("Volume", 1f);
            SetVolume(playerPrefsVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SetVolume(volumeOnExit);
        }
    }

    private void SetVolume(float volume)
    {
        if(audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
