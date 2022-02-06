using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundAmount : Amount
{
    List<Amount> amountComponents;

    public override float GetAmount(Transform target)
    {
        float result = 0;
        foreach(Amount amount in amountComponents)
        {
            result += amount.GetAmount(target);
        }
        return result;
    }
}
