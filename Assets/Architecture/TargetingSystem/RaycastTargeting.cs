using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Raycast Target",menuName = "Targeting System/Raycast Target")]
public class RaycastTargeting : TargetingMethod
{
    Ray RayOrigin;
    RaycastHit HitInfo;
    public LayerMask HitMask;
    public float targetLifetime;
    public float range = 100f;
    public bool placeTransform;
    public bool onHitEffect = false;
    public Effect hitEffect;

    public override List<Transform> GetTargets(Transform user)
    {
        List<Transform> result = new List<Transform>();
        RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(RayOrigin, out HitInfo, range, HitMask))
        {
            if (placeTransform || onHitEffect)
            {
                GameObject g = new GameObject();
                g.transform.parent = null;
                g.transform.position = HitInfo.point;
                g.transform.rotation = user.rotation;
                TimedDeath d = g.AddComponent<TimedDeath>();
                d.lifetime = targetLifetime;
                if(placeTransform) result.Add(g.transform);
                if (onHitEffect)
                {
                    hitEffect.Apply(g.transform);
                }
            }
            if(!placeTransform)
            {
                result.Add(HitInfo.collider.transform);
            }
        }
        return result;
    }
}
