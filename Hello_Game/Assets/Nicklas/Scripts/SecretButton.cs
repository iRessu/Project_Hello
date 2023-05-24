using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{

    public float requiredTime;
    public GameObject objectToActivate;
    private bool playerInsideTrigger;
    private float currentTime = 0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            currentTime = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            currentTime = 0f;
        }
    }
    void Update()
    {
        if(playerInsideTrigger)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= requiredTime)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
