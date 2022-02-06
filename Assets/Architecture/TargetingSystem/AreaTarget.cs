using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "Area Target",menuName = "Targeting System/Area Target")]
public class AreaTarget : TargetingMethod
{
    public FloatReference radius;
    public LayerMask targetingLayers;
    public override List<Transform> GetTargets(Transform user)
    {
        List<Transform> result = new List<Transform>();
        Collider[] collisions = Physics.OverlapSphere(user.transform.position, radius.Value, targetingLayers);
        return GetTargetsFromCollisions(user.position,result, collisions);
    }

    private List<Transform> GetTargetsFromCollisions(Vector3 origin,List<Transform> result, Collider[] collisions)
    {
        foreach (Collider col in collisions)
        {
            if (!result.Contains(col.transform))
            {
                Ray ray = new Ray(origin,col.transform.position-origin);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,radius))
                {
                    if(hit.collider == col)
                    {
                        result.Add(col.transform);
                    }
                }
            }
        }
        return result;
    }
}
