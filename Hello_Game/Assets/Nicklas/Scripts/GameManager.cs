using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("GameManager");
                    instance = managerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }




    private Dictionary<string, bool> doorStates;
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        doorStates = new Dictionary<string, bool>();
        keyList = new List<Key.KeyType>();
    }


    public void SetDoorState(string doorKey, bool isOpen)
    {
        if(doorStates.ContainsKey(doorKey))
        {
            doorStates[doorKey] = isOpen;
        }

        else
        {
            doorStates.Add(doorKey, isOpen);
        }
    }

    public bool GetDoorState(string doorKey)
    {
        return doorStates.ContainsKey(doorKey) && doorStates[doorKey];
    }

    public void AddKey(Key.KeyType keyType)
    {
        if(!keyList.Contains(keyType))
        {
            keyList.Add(keyType);
        }
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType); 
    }

    public bool ContainsKey(Key.KeyType keytype)
    {
        return keyList.Contains(keytype);
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

}
  
   