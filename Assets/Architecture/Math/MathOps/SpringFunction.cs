using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpringFunction : ScriptableObject
{
    public abstract float Calculate(float distance, float strength, float checkDistance, float dampening, ref float lastHit);
}
