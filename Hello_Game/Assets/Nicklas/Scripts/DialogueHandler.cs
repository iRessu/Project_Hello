using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;
    public float displayTime = 3f;
    

    private string fullText;

    private void Start()
    {
        fullText = dialogueText.text;
        dialogueText.text = "";

        StartCoroutine(TypeText());
        
    }

    private IEnumerator TypeText()
    {
        foreach(char c in fullText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);

        }

        yield return new WaitForSeconds(displayTime);

        dialogueText.enabled = false;
    }
}
