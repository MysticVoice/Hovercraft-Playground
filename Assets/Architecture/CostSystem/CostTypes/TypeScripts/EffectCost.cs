using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect Cost",menuName = "Cost System/Effect Cost")]
public class EffectCost : CostType
{
    public TargetingMethod targeting;
    public Effect effect;

    public override void TakeCost(Transform target, float amount = 0)
    {
        foreach (Transform t in targeting.GetTargets(target))
        {
            effect.Apply(target);
        }
    }

    public override bool ValidateResourceAmmount(Transform target,float amount)
    {
        return true;
    }
}
