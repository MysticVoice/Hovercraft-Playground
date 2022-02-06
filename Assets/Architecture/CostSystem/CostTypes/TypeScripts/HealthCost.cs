using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Health Cost",menuName = "Cost System/Health Cost")]
public class HealthCost : CostType
{
    public override void TakeCost(Transform target, float amount)
    {
        Health h = target.GetComponent<Health>();
        h.Decrease(Mathf.FloorToInt(amount));
    }

    public override bool ValidateResourceAmmount(Transform target,float amount)
    {
        Health h = target.GetComponent<Health>();
        if (!canOverflow && h.currentValue.Value - amount < 1) return false;
        if (canOverflow && h.currentValue.Value <= 1) return false;
        else return true;
    }
}
