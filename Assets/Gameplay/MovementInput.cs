using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.InputSystem;

public class MovementInput : MonoBehaviour
{
    public CharacterController thirdPersonCharacter;
    public FloatReference rotationSensetivity;
    public FloatReference movementSensetivity;
    public FloatReference jumpPower;
    public FloatReference gravity;

    public FloatReference horizontalInput;
    public FloatReference verticalInput;
    public BoolReference jumpInput;
    public FloatReference turnInput;

    private float mouseX;
    private float mouseY;
    private float vertical;
    private float horizontal;
    private float verticalMomentum;
    private bool jump;

    public void Update()
    {
        CaptureInput();
    }
    public void FixedUpdate()
    {
        CalculateVerticalMomentum();
        transform.Rotate(Vector3.up,mouseX*rotationSensetivity);
        thirdPersonCharacter.Move((transform.forward*vertical*movementSensetivity)+(transform.right*horizontal*movementSensetivity)+Vector3.up*verticalMomentum);
    }

    public void CaptureInput()
    {
        mouseX = turnInput.Value;
        vertical = verticalInput.Value;
        horizontal = horizontalInput.Value;
        jump = jumpInput.Value;
    }

    public void CalculateVerticalMomentum()
    {
        verticalMomentum -= gravity * Time.deltaTime;
        if(jump)
        {
            verticalMomentum = gravity * jumpPower;
            jump = false;
        }
        verticalMomentum = Mathf.Clamp(verticalMomentum,-gravity,gravity*3);
    }
}
