using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverStabilizer : MonoBehaviour
{
    HoverSettings hoverSettings;
    public bool grounded;
    Rigidbody rb;
    public float dampening = 0.1f;
    public float verticalDampen = 0.1f;

    public float rotationalDampening = 0.3f;
    public float rotationalAdjustment = 0.3f;

    RaycastHit hit;
    public float rayLength = 8;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = false;
        hoverSettings = HoverSettings.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = GroundCheck();
        if (grounded)
        {
            LinearStabilization();
        }
        else
        {
            //RotationalStabilization();
        }
    }

    private void LinearStabilization()
    {
        Vector3 v = -rb.velocity;
        v.x *= dampening;
        v.z *= dampening;
        v.y *= verticalDampen;
        rb.AddForce(v);
    }

    private void RotationalStabilization()
    {
        Quaternion deltaQuat = Quaternion.FromToRotation(rb.transform.up, Vector3.up);
        Vector3 axis;
        float angle;
        deltaQuat.ToAngleAxis(out angle, out axis);
        rb.AddTorque(-rb.angularVelocity * rotationalDampening, ForceMode.Acceleration);
        rb.AddTorque(axis.normalized * angle * rotationalAdjustment, ForceMode.Acceleration);
    }
    private bool GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength,hoverSettings.hoverRaycastMask))
        {
            return true;
        }
        else return false;
    }
}
