using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CostType : ScriptableObject
{
    public bool canOverflow;
    //public abstract float GetAmmount(Transform target);
    public abstract void TakeCost(Transform target, float amount);
    public abstract bool ValidateResourceAmmount(Transform target, float amount);
}
