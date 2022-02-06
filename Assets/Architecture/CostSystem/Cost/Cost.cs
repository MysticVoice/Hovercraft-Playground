using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Cost",menuName = "Cost System/Cost")]
public class Cost : ScriptableObject
{
    public CostType type;
    public FloatReference amount;
    public void TakeCost(Transform target)
    {
        type.TakeCost(target,amount);
    }
    
    public bool CheckRequiredCost(Transform target)
    {
        return type.ValidateResourceAmmount(target,amount);
    }
}
