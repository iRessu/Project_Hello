using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("ExploreTheme");
    }
}