using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(fileName = "New Inventory",menuName = "Item System/Inventory")]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabase database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(Item item, int amount)
    {
        for(int i = 0;i<Container.Count;i++)
        {
            if (Container[i].item == item && Container[i].amount<item.stackSize)
            {
                Container[i].AddAmount(amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.itemIdPair[item],item, amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this,true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath,savePath));
        bf.Serialize(file,saveData);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath,savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.getItem(Container[i].id);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}



[System.Serializable]
public class InventorySlot
{
    public int id;
    public Item item;
    public int amount;
    public InventorySlot(int id,Item item, int amount)
    {
        this.id = id;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
