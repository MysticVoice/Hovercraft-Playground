using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Mana Drain",menuName = "Effect System/Mana Drain")]
public class ManaDrainEffect : Effect
{
    public int amount;
    public override void Apply(Transform target)
    {
        target.GetComponent<Mana>().Decrease(amount);

    }
}
