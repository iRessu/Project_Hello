using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public int audioSourceCount = 2;

    private List<AudioSource> audioSources;
    private int currentAudioSourceIndex = 0;

    private void Awake()
    {
        audioSources = new List<AudioSource>(audioSourceCount);

        for(int i = 0; i < audioSourceCount; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
        }
    }

    public AudioSource GetAvailableAudioSource()
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            int index = (currentAudioSourceIndex + i) % audioSources.Count;
            AudioSource audioSource = audioSources[index];

            if(!audioSource.isPlaying)
            {
                currentAudioSourceIndex = (index + 1) % audioSources.Count;
            }
        }


        Debug.LogWarning("All audio sources are in use");
        return null;
    }
}
