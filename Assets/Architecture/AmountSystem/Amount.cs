using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Amount : ScriptableObject
{
    public abstract float GetAmount(Transform target);
}
