using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public float rangeModifier = 0;
    private void OnEnable()
    {
        PickupManager.pickup += Pickup;
    }
    private void OnDisable()
    {
        PickupManager.pickup -= Pickup;
    }
    private void Pickup(Vector3 pos)
    {
        if (pickupInRange(pos))
        {
            if (PickupManager.instance.playerInventory == null) Debug.Log("inventory null");
            if (item == null) Debug.Log("item null");
            PickupManager.instance.playerInventory.AddItem(item,1);
            Destroy(this.gameObject);
        }
    }

    private bool pickupInRange(Vector3 pos)
    {
        return Vector3.Distance(transform.position,pos)<PickupManager.pickupRange+rangeModifier;
    }
}
