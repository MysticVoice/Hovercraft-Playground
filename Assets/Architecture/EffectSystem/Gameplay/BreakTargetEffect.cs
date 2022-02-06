using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Break Target Lock",menuName = "Effect System/Break Target Lock")]
public class BreakTargetEffect : Effect
{
    public override void Apply(Transform target)
    {
        target.GetComponent<Turret>().target = null;
    }
}
