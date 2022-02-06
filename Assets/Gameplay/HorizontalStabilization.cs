using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalStabilization : MonoBehaviour
{
    Rigidbody rb;
    public float dampening = 0.1f;
    public float verticalDampen = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Stabilize();
    }

    private void Stabilize()
    {
        Vector3 v = -rb.velocity;
        v.y *= verticalDampen;
        rb.AddForce(v*dampening);
    }
}
