using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn At Target",menuName = "Effect System/Spawn At Target")]
public class SpawnAtTargetEffect : Effect
{
    public GameObject prefab;
    public override void Apply(Transform target)
    {
        GameObject g = Instantiate(prefab);
        g.transform.position = target.position;
        g.transform.rotation = target.rotation;
    }
}
