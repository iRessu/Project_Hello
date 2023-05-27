using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private Sound currentSound;
    public bool isPaused = false;

    public AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
       
        DontDestroyOnLoad(gameObject);


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound newSound = Array.Find(sounds, sound => sound.name == name);
        if (newSound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if(currentSound != null && !isPaused)
        {
            currentSound.source.Stop();
        }

        newSound.source.Play();
        currentSound = newSound;
    }

    public void PauseMusic()
    {
        if(currentSound != null && !isPaused)
        {
            currentSound.source.Pause();
            isPaused = true;
        }
    }

    public void ResumeMusic()
    {
        if(currentSound != null && isPaused)
        {
            currentSound.source.UnPause();
            isPaused = false;
        }
    }

    public void SetGlobalVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }
}
