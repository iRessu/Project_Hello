using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    
    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;

    public DialogueManager dialogueManager;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }
    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);

        if(keyType == Key.KeyType.Red)
        {
            dialogueManager.SetDialogue("This must be the key \n to my parents room!");
        }
        else
        {
            dialogueManager.SetDialogue("I found a key \n Which door will it unlock?");
        }
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
                dialogueManager.SetDialogue("I unlocked the door");
            }
            else if(HasKeyButWrongDoor(keyDoor.GetKeyType()))
            {
                dialogueManager.SetDialogue("The key does not fit");
            }
            else
            {
                dialogueManager.SetDialogue("The door is locked");
            }
        }
    }

    private bool HasKeyButWrongDoor(Key.KeyType requiredKeyType)
    {
        foreach(Key.KeyType keyType in keyList)
        {
            if(keyType != requiredKeyType)
            {
                return true;
            }
        }
        return false;
    }
}
