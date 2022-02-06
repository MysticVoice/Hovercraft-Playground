using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Move",menuName ="Effect System/MovementEffect")]
public class MoveEffect : Effect
{
    public Vector3Reference direction;
    public override void Apply(Transform target)
    {
        target.position += direction.Value;
    }
}
