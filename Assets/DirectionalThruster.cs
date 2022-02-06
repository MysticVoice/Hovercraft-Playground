using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
public class DirectionalThruster : MonoBehaviour
{
    Rigidbody rb;
    public FloatReference forwardInput;
    public FloatReference horizontalInput;
    public FloatReference verticalInput;

    public FloatReference forwardPower;
    public FloatReference horizontalPower;
    public FloatReference verticalPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Thrust(forwardInput*forwardPower,transform.forward);
        Thrust(horizontalInput*horizontalPower,transform.right);
        Thrust(verticalInput*verticalPower,transform.up);
    }

    private void Thrust(float power, Vector3 direction)
    {
        rb.AddForceAtPosition(direction*power,transform.position);
    }
}
