using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Consumable,
    Equipment,
    Default
}
//[CreateAssetMenu(fileName = "New Item", menuName = "ItemSystem/Item/Default")]
public abstract class Item : ScriptableObject
{
    public Sprite sprite;
    public GameObject prefab;
    public ItemType type;
    public int stackSize = 100;
    [TextArea(15, 20)]
    public string description;
}