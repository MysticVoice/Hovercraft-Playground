using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class MystLogic
{
    public static bool InRange(float input, float min, float max)
    {
        return (min < input && input < max);
    }
}
