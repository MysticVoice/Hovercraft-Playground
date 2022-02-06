using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Target By Name",menuName ="Targeting System/Target By Name")]
public class NameTarget : TargetingMethod
{
    public StringReference targetName;
    public override List<Transform> GetTargets(Transform user)
    {
        return new List<Transform> { GameObject.Find(targetName).transform };
    }
}
