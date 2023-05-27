using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretANButton : MonoBehaviour
{

    public GameObject objectToActivate;
    public float activationDuration;
    public int requiredPresses;

    private int pressCount;
    private bool isObjectActivated;
    private Coroutine activationCoroutine;

    // Update is called once per frame
    void Update()
    {
        if(!isObjectActivated && pressCount >= requiredPresses)
        {
            ActivateObject();
        }
    }


    public void ButtonPresses()
    {
        pressCount++;
    }

    private void ActivateObject()
    {
        if(activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        activationCoroutine = StartCoroutine(ActivateDeactivateObject());
    }

    private IEnumerator ActivateDeactivateObject()
    {
        isObjectActivated = true;
        objectToActivate.SetActive(true);

        yield return new WaitForSeconds(activationDuration);

        objectToActivate.SetActive(false);
        pressCount = 0;

        isObjectActivated = false;
    }
}
