using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class Gyroscope : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float turnForce = 50;
    public FloatReference turnInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotationalStabilization();
        RotationalControl();
    }

    private void RotationalStabilization()
    {
        Vector3 up = Vector3.up;
        Vector3 rbUp = rb.transform.up;
        Vector3 torque = Vector3.Cross(rbUp,up);
        float dot = Vector3.Dot(rbUp,up);
        rb.AddTorque((torque*force)*(1-dot));
    }

    private void RotationalControl()
    {
        Vector3 torque = transform.up*turnInput;
        rb.AddTorque(torque * turnForce);
    }
}
