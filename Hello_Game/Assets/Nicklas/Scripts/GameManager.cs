using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameData gameData;

    private void Awake()
    {
        if(instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        LoadGameData();

    }

    public void AddKey(Key.KeyType keyType)
    {
        if(!gameData.collectedKeys.Contains(keyType))
        {
            gameData.collectedKeys.Add(keyType);
            SavedGameData();
        }
         
        
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        gameData.collectedKeys.Remove(keyType);
        SavedGameData();
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return gameData.collectedKeys.Contains(keyType);
    }

    public void OpenDoor(Key.KeyType keyType)
    {
        if(!gameData.openedDoors.Contains(keyType))
        {
            gameData.openedDoors.Add(keyType);
            SavedGameData();
        }
    }

    public bool IsDoorOpen(Key.KeyType keyType)
    {
        return gameData.openedDoors.Contains(keyType);
    }

    private void LoadGameData()
    {
        GameData savedGameData = Resources.Load<GameData>("SavedGameData");

        if(savedGameData != null)
        {
            gameData.collectedKeys = savedGameData.collectedKeys;
            gameData.openedDoors = savedGameData.openedDoors;
        }
        else
        {
            gameData.collectedKeys = new List<Key.KeyType>();
            gameData.openedDoors = new List<Key.KeyType>();
        }
    }

    private void SavedGameData()
    {
        GameData savedGameData = Resources.Load<GameData>("SavedGameData");

        if(savedGameData == null)
        {
            savedGameData = ScriptableObject.CreateInstance<GameData>();
            UnityEditor.AssetDatabase.CreateAsset(savedGameData, "Assets/Resources/SavedGameData.asset");
        }

        savedGameData.collectedKeys = gameData.collectedKeys;
        savedGameData.collectedKeys = gameData.openedDoors;

      
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }


}
  
   