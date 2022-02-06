using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetingMethod : ScriptableObject
{
    public abstract List<Transform> GetTargets(Transform user);
}
