using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class AxialStabilizer : MonoBehaviour
{
    private Rigidbody rb;
    public FloatReference linearPower;
    public FloatReference dampening;
    public FloatReference forwardInput;
    public FloatReference strafeInput;
    public FloatReference verticalInput;
    public FloatReference passivePower;
    
    public bool groundCheck;
    public FloatReference groundDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!groundCheck)
        {
            LinearStabilization();
        }
    }

    private void LinearStabilization()
    {
         Vector3 stearingDirection = Vector3.zero;
         stearingDirection += transform.forward * GetLinearComponent(2, forwardInput);
         stearingDirection += transform.right * GetLinearComponent(0, strafeInput);
         //stearingDir += transform.up * GetLinearComponent(1,verticalInput);
         rb.AddForceAtPosition(stearingDirection * linearPower, transform.position);

    }

    public float GetLinearComponent(int axis,float input)
    {
        Vector3 velocity = rb.velocity;
        velocity = transform.InverseTransformVector(velocity);
        float vect;
        if (axis == 0) vect = velocity.x;
        else if (axis == 1) vect = velocity.y;
        else vect = velocity.z;
        if (input == 0)
        {
            float value = Mathf.Clamp(-vect * dampening, -passivePower, passivePower);
            return value;
        }

        else return input;
    }


}
