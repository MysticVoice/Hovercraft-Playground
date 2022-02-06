using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hokes Law",menuName = "Spring Function/Hokes Law")]
public class HookesLaw : SpringFunction
{
    public override float Calculate(float hitDistance,float strength, float length,float dampening, ref float lastHitDist)
    {
        float forceAmount = strength * (length - hitDistance) + (dampening * (lastHitDist - hitDistance));
        forceAmount = Mathf.Max(0, forceAmount);
        lastHitDist = hitDistance;
        return forceAmount;
    }
}
