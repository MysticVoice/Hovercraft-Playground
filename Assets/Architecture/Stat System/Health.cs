using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.Events;

public class Health : ConsumableStat
{
    public UnityEvent deathEvent;
    public void Decrease(int amount)
    {
        base.Decrease(amount);
        if (currentValue.Value <= 0)
        {
            deathEvent?.Invoke();
        }
    }
}
