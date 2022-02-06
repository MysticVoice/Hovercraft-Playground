using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "No Cost",menuName = "Cost System/No Cost")]
public class NoCost : CostType
{
    public override void TakeCost(Transform target, float amount = 0) { }

    public override bool ValidateResourceAmmount(Transform target,float amount)
    {
        return true;
    }
}
