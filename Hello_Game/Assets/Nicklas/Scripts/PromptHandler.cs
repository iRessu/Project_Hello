using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptHandler : MonoBehaviour
{
    public TextMeshProUGUI textPrompt;
    private DialogueManager dm;


    public GameObject objectToDestroy;


    private Coroutine promptCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        textPrompt.enabled = false;
        dm = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            promptCoroutine = StartCoroutine(DisplayPrompt());
        }
    }


    private IEnumerator DisplayPrompt()
    {
        textPrompt.enabled = true;
        string promptText = textPrompt.text;
        textPrompt.text = "";
        dm.SetDialogue(promptText);

        yield return new WaitForSeconds(3);

        textPrompt.enabled = false;
        Destroy(objectToDestroy);
    }


}
