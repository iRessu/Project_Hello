using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialoguePrompt;
    public float typingSpeed = 0.05f;
    public float displayDuration = 2f;

    private Coroutine typingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePrompt.text = "";
    }

    public void SetDialogue(string dialogue)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialoguePrompt.text = "";

        typingCoroutine = StartCoroutine(TypeText(dialogue));
    }

    private IEnumerator TypeText(string dialogue)
    {
        foreach(char c in dialogue)
        {
            dialoguePrompt.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(displayDuration);
        dialoguePrompt.text = "";
    }
}
