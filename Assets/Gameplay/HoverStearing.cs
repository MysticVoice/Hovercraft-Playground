using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class HoverStearing : MonoBehaviour
{
    Rigidbody rb;
    HoverStabilizer hs;
    public FloatReference forwardPower;
    public FloatReference rotationPower;
    public FloatReference sideways;
    public FloatReference forward;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hs = GetComponent<HoverStabilizer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControlHovercraft();
    }

    private void ControlHovercraft()
    {
        if (hs.grounded) rb.AddForce(transform.forward * forward.Value * forwardPower.Value);
        rb.AddTorque(transform.up * rotationPower.Value * sideways.Value);
    }
}
