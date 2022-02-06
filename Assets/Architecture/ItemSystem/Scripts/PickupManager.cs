using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private static PickupManager s_Instance = null;
    public static PickupManager instance
    {
        get
        {
            if (s_Instance == null) s_Instance = FindObjectOfType(typeof(PickupManager)) as PickupManager;
            if(s_Instance == null)
            {
                var obj = new GameObject("Pickup Manager");
                s_Instance = obj.AddComponent<PickupManager>();
            }
            return s_Instance;
        }
    }
    void OnApplicationQuit()
    {
        s_Instance = null;
    }

    public static event Action<Vector3> pickup;
    public static float pickupRange = 3;
    public Inventory playerInventory;
    // Update is called once per frame
    void FixedUpdate()
    {
        pickup?.Invoke(transform.position);
    }
}
