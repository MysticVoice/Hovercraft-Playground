using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetPredictor
{
    public static Vector3 PredictLocation(Vector3 target, Vector3 velocity, Vector3 origin, float projectileSpeed)
    {
        return (target + ((velocity * (target - origin).magnitude) / projectileSpeed));
    }
    #region PredictLocation Overloads
    public static Vector3 PredictLocation(Transform target, Rigidbody rigidbody, Transform origin, float projectileSpeed,bool useRelativeSpace)
    {
        if (useRelativeSpace) PredictLocation(origin.InverseTransformVector(target.position),origin.InverseTransformVector(rigidbody.velocity),origin.position,projectileSpeed);
        return PredictLocation(target.position, rigidbody.velocity, origin.position, projectileSpeed);
    }
    public static Vector3 PredictLocation(Transform target, Rigidbody rigidbody, Vector3 origin, float projectileSpeed)
    {
        return PredictLocation(target.position, rigidbody.velocity, origin, projectileSpeed);
    }
    public static Vector3 PredictLocation(Vector3 target, Rigidbody rigidbody, Transform origin, float projectileSpeed)
    {
        return PredictLocation(target, rigidbody.velocity, origin.position, projectileSpeed);
    }
    public static Vector3 PredictLocation(Transform target, Vector3 velocity, Transform origin, float projectileSpeed)
    {
        return PredictLocation(target.position, velocity, origin.position, projectileSpeed);
    }
    public static Vector3 PredictLocation(Vector3 target, Vector3 velocity, Transform origin, float projectileSpeed)
    {
        return PredictLocation(target, velocity, origin.position, projectileSpeed);
    }
    public static Vector3 PredictLocation(Transform target, Vector3 velocity, Vector3 origin, float projectileSpeed)
    {
        return PredictLocation(target.position, velocity, origin, projectileSpeed);
    }
    public static Vector3 PredictLocation(Vector3 target, Rigidbody rigidbody, Vector3 origin, float projectileSpeed)
    {
        return PredictLocation(target, rigidbody.velocity, origin, projectileSpeed);
    }
    #endregion
}
