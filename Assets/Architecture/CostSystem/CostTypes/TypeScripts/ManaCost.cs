using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Mana Cost",menuName ="Cost System/Mana Cost")]
public class ManaCost : CostType
{

    public override void TakeCost(Transform target, float amount)
    {
        Mana h = target.GetComponent<Mana>();
        h.Decrease(Mathf.FloorToInt(amount));
    }

    public override bool ValidateResourceAmmount(Transform target,float amount)
    {
        Mana h = target.GetComponent<Mana>();
        if (!canOverflow && h.currentValue.Value - amount < 0) return false;
        else return true;
    }
}
