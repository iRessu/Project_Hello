using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallPrompt : MonoBehaviour
{
    private DialogueManager dm;
    

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }


    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            dm.SetDialogue("Their room is downstairs behind the kitchen");
            yield return new WaitForSeconds(4);
            Destroy(this.gameObject);
        }
    }

}
