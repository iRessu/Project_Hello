using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PauseMusic();
    }
}
