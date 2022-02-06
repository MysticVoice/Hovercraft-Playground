using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    public CharacterController thirdPersonCharacter;
    public float rotationSensetivity;
    public float movementSensetivity = 0.1f;
    public float jumpPower = 3;
    public float gravity = 9.81f;
    private float mouseX;
    private float mouseY;
    private float vertical;
    private float horizontal;
    private float verticalMomentum;
    private bool jumpInput;
    
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
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    public void CalculateVerticalMomentum()
    {
        verticalMomentum -= gravity * Time.deltaTime;
        if(jumpInput)
        {
            verticalMomentum = gravity * jumpPower;
            jumpInput = false;
        }
        verticalMomentum = Mathf.Clamp(verticalMomentum,-gravity,gravity*3);
    }
}
