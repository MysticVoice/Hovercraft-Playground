using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item database",menuName ="Item System/Items/Database")]
public class ItemDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public Item[] items;
    public Dictionary<Item, int> itemIdPair = new Dictionary<Item, int>();

    public void OnAfterDeserialize()
    {
        RefreshDatabase();
    }

    public void Awake()
    {
        RefreshDatabase();
    }

    public void RefreshDatabase()
    {
        itemIdPair = new Dictionary<Item, int>();
        for (int i = 0; i < items.Length; i++)
        {
            itemIdPair.Add(items[i], i);
        }
    }

    public Item getItem(int i)
    {
        foreach (KeyValuePair<Item, int> keyValuePair in itemIdPair)
        {
            //Container[keyValuePair.Value].item = keyValuePair.Key;
            if (keyValuePair.Value == i) return keyValuePair.Key;
        }
        return null;
    }
    public void OnBeforeSerialize()
    {
    }
}
