using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretButtonActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    public int requiredPresses;

    private int pressCount;

    private void Update()
    {
        if(pressCount >= requiredPresses)
        {
            objectToActivate.SetActive(true);
        }
    }


    public void ButtonPressCount()
    {
        pressCount++;
    }
}
