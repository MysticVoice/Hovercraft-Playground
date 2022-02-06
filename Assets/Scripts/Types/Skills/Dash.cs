using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    Rigidbody rb;
    public float dashPower;
    public int dashFrames = 30;
    private int dashCounter;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        enabled = false;
        dashCounter = 0;
    }
    public override void use()
    {
        enabled = true;
        dashCounter = dashFrames;
        //rb.MovePosition(transform.position + transform.up * dashPower);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * dashPower);
        dashCounter--;
        if(dashCounter == 0)
        {
            enabled = false;
        }
    }
}
