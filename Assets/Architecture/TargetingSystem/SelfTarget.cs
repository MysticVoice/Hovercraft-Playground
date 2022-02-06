using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Self Target",menuName = "Targeting System/Self")]
public class SelfTarget : TargetingMethod
{
    public override List<Transform> GetTargets(Transform user)
    {
        return new List<Transform> { user };
    }
}
