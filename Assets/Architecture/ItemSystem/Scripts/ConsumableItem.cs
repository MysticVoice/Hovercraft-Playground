using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Item System/Items/Consumable Item")]
public class ConsumableItem : Item
{
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
