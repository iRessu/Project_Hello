using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 01f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        FindObjectOfType<AudioManager>().instance.SetGlobalVolume(volume);

        PlayerPrefs.SetFloat("Volume", volume);
    }
}
