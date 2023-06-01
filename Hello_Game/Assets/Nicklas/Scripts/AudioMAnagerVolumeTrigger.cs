using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMAnagerVolumeTrigger : MonoBehaviour
{
    private AudioManager audioManager;
    private float volumeOnEnter = 0f;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetFloat("Volume", 1f) >= 0f)
        {
            SetVolume("ExploreTheme", volumeOnEnter);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float playerPrefVolume = PlayerPrefs.GetFloat("Volume", 1f);
            SetVolume("ExploreTheme", playerPrefVolume);
        }
    }

    private void SetVolume(string soundName, float volume)
    {
        audioManager.SetVolume(soundName, volume);
    }
}
