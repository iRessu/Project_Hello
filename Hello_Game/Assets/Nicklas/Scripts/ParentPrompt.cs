using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPrompt : MonoBehaviour
{
    public GameObject colliderToActivate;
    public GameObject colliderToDeActivate;
    private DialogueManager dm;




    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            StartCoroutine(WaitTilActivating());
        }
    }

    private IEnumerator WaitTilActivating()
    {
        dm.SetDialogue("Weird, the door to my parents room is locked, I should search for the key");
        yield return new WaitForSeconds(5);
        colliderToActivate.SetActive(true);
        colliderToDeActivate.SetActive(false);
    }
}
