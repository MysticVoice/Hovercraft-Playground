using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability",menuName = "Ability System/Ability")]
public class Ability : ScriptableObject
{
    public Cost cost;
    public TargetingMethod targeting;
    public Effect effect;
    public void Use(Transform user)
    {
        if (cost.CheckRequiredCost(user))
        {
            cost.TakeCost(user);
            foreach (Transform t in targeting.GetTargets(user))
            {
                effect.Apply(t);
            }
        }
    }
}
