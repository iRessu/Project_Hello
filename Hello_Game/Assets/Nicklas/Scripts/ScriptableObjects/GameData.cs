using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    public List<Key.KeyType> collectedKeys;
    public List<Key.KeyType> openedDoors;
}
