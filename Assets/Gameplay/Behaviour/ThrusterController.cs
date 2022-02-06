using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    public float forwardsThrust = 10;
    public float sidewaysThrust = 5;
    public float verticalThrust = 2;
    public float rotationForce = 1;
    public bool stabilize = false;
    public float coneAnimationSpeed = 0.05f;
    public float changeThrustWeight = 0.05f;
    public float changeThrustVerticalWeight = 0.05f;
    private float throttleForward;
    private float throttleSidways;
    private float throttleVertical;
    private Rigidbody rb;
    public SkinnedMeshRenderer[] thrustCones;
    private float targetConeState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        throttleForward = 0;
        throttleSidways = 0;
        if (thrustCones.Length == 0) this.enabled = false;
    }

    private void Update()
    {
        if (throttleForward > targetConeState) targetConeState += coneAnimationSpeed;
        else targetConeState -= coneAnimationSpeed;
        targetConeState = Mathf.Clamp(targetConeState, 0, 1);
        foreach (SkinnedMeshRenderer thrustCone in thrustCones)
        {
            thrustCone.SetBlendShapeWeight(0, Remap.map(targetConeState, 0, 1, 30, 100));
        }
    }

    public void thrust(float horizontalInput, float forwardInput, float verticalInput, float strafeInput)
    {
        Vector3 thrustDirection = Vector3.zero;
        throttleForward = ChangeThrust(throttleForward, forwardInput, changeThrustWeight);
        throttleSidways = ChangeThrust(throttleForward, horizontalInput, changeThrustWeight);
        throttleVertical = ChangeThrust(throttleVertical, verticalInput, changeThrustVerticalWeight);
        thrustDirection += CalculateThrust(throttleForward, transform.forward,forwardsThrust);
        thrustDirection += CalculateThrust(throttleSidways,transform.right,sidewaysThrust);
        thrustDirection += VerticalThrust(verticalInput)*verticalThrust;
        rb.AddForce(thrustDirection);
        rb.AddTorque(horizontalInput*rotationForce * Vector3.up);
    }

    public void thrustWorldSpace(float horizontalInput, float forwardInput, float strafeInput, float verticalInput)
    {
        Vector3 thrustDirection = Vector3.zero;
        throttleForward = ChangeThrust(throttleForward,forwardInput,changeThrustWeight);
        throttleSidways = ChangeThrust(throttleForward, horizontalInput, changeThrustWeight);
        throttleVertical = ChangeThrust(throttleVertical,verticalInput,changeThrustVerticalWeight);
        //ChangeThrustSideways(horizontalInput);
        thrustDirection += CalculateThrust(throttleForward,Vector3.forward, forwardsThrust);
        thrustDirection += CalculateThrust(throttleSidways, Vector3.right, sidewaysThrust);
        thrustDirection += CalculateThrust(throttleVertical, Vector3.up, verticalThrust);
        rb.AddForce(thrustDirection);
        rb.AddTorque(horizontalInput * rotationForce * Vector3.up);
    }

    public void ResetThrottle()
    {
        throttleForward = 0;
    }

    public Vector3 CalculateThrust(float input, Vector3 direction, float force)
    {
        return direction * force * input;
    }

    public float ChangeThrust(float currentThrust,float input,float weight)
    {
        currentThrust += input * weight;
        currentThrust = Mathf.Clamp(currentThrust, -1, 1);
        return currentThrust;
    }

    public Vector3 VerticalThrust(float input)
    {
        return Vector3.up*input;
    }
}
