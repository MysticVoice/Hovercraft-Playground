using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class ConsumableStat : MonoBehaviour
{
    public IntReference currentValue;
    public IntReference maxValue;

    void Start()
    {
        currentValue.Value = maxValue.Value;
    }
    public void Decrease(int amount)
    {
        currentValue.Value -= amount;
    }
    public void Increase(int amount)
    {
        if (currentValue + amount <= maxValue) currentValue.Value += amount;
        else currentValue.Value = maxValue;
    }

    public float NormalizeStat()
    {
        return currentValue.Value / (float)maxValue.Value;
    }
}
