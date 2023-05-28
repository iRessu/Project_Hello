using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidTriggerScript : MonoBehaviour
{
    public string pianoSong;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Piano");
        }
    }
}
