using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class Hover : MonoBehaviour
{
    HoverSettings hoverSettings => HoverSettings.Instance;
    Rigidbody rb;
    Quaternion qt;
    public FloatReference xSteering;
    public FloatReference ySteering;
    public FloatReference strafeSteering;

    public FloatReference rayLength;
    public FloatReference strength;
    public FloatReference dampening;
    public FloatReference spherecastRadius;
    public float maxRotationAngle = 45;

    public Transform upReference;

    public FloatReference maxForce;
    private float lastHit;
    private Vector3 steeringDirection;
    RaycastHit hit;
    public SpringFunction springFunction;

    int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        lastHit = rayLength * 1.1f;
        steeringDirection = Vector3.zero;
        qt = GetComponent<Quaternion>();
        frameCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCounter++;
        Vector3 forceDirection = transform.parent.up;
        Vector3 nonVerticalComponent = GetSteeringDirection();
        //nonVerticalComponent.Normalize();
        forceDirection += nonVerticalComponent/2;
        forceDirection.Normalize();
        //transform.forward = forceDirection;
        float multiplier = maxRotationAngle;
        if (frameCounter % 30 == 0) Debug.Log(nonVerticalComponent);
        transform.up = forceDirection;

        if (Physics.Raycast(transform.position, -transform.up, out hit, rayLength, hoverSettings.hoverRaycastMask))
        {
            float forceAmount = springFunction.Calculate(hit.distance, strength, rayLength, dampening, ref lastHit);
            forceAmount = Mathf.Clamp(forceAmount, 0, maxForce);
            rb.AddForceAtPosition(forceDirection * forceAmount, transform.position);
        }
        else lastHit = rayLength * 1.1f;
    }


    private Vector3 GetSteeringDirection()
    {
        Vector3 result;
        float rotComponent = GetRotationalComponent();
        rotComponent += GetStrafeComponent();
        rotComponent = Mathf.Clamp(rotComponent,-1f,1f);
        steeringDirection.x = Mathf.Lerp(steeringDirection.x,rotComponent,0.1f);
        steeringDirection.z = Mathf.Lerp(steeringDirection.z,ySteering,0.1f);
        //steeringDirection = Vector3.Lerp(steeringDirection, new Vector3(rotComponent,0, ySteering),0.1f);
        result = transform.parent.localToWorldMatrix.MultiplyVector(steeringDirection);
        return result;
        
    }

    private float GetStrafeComponent()
    {
        return strafeSteering;
    }

    private float GetRotationalComponent()
    {
        float result;
        float forwardPosition = transform.parent.localPosition.z;
        if (forwardPosition > rb.centerOfMass.z) result = xSteering;
        else result = -xSteering;
        return result;
    }
}
