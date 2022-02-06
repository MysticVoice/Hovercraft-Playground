using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Damage Effect",menuName ="Effect System/DamageEffect")]
public class DamageEffect : Effect
{
    public IntReference damage;
    public override void Apply(Transform target)
    {
        target.GetComponent<Health>()?.Decrease(damage);
    }
}
