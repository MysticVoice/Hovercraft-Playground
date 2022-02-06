using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(ThrusterController))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private ThrusterController tc;
    public Skill skill;
    public Fire fire;
    public float firerate;
    public ControllMode controllMode;
    public Target mouseTarget;
    public List<SkinnedMeshRenderer> ThrustCones;

    private bool shiftInput;
    private bool fireInput;
    private int waitFrames;
    private bool throttleReset;

    public enum ControllMode
    {
        Default,
        PointToMouse,
        GlobalAxis
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tc = GetComponent<ThrusterController>();
        fire = GetComponent<Fire>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) shiftInput = true;
        fireInput = Input.GetButton("Fire1");
        throttleReset = Input.GetKey(KeyCode.X);
        //if (Input.GetButton("Fire1")) fireInput = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(controllMode)
        {
            case ControllMode.Default:
                tc.thrust(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),Input.GetAxis("UpDown"), Input.GetAxis("Strafe"));
                if (throttleReset) tc.ResetThrottle();
                break;
            case ControllMode.PointToMouse:
                tc.thrust(VectorTools.getWeightedTurnDirection(mouseTarget.trackTarget(),transform,20f), Input.GetAxis("Vertical"),0, Input.GetAxis("Horizontal"));
                break;
            case ControllMode.GlobalAxis:
                tc.thrustWorldSpace(VectorTools.getWeightedTurnDirection(mouseTarget.trackTarget(), transform, 20f), Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetAxis("UpDown"));
                break;
        }
        
        if (shiftInput)
        {
            skill.use();
            shiftInput = false;
        }
        if (fireInput)
        {
            fire.fire();
            fireInput = false;
            setWaitFrames();
        }
        else if (waitFrames > 0) waitFrames--;
    }

    void setWaitFrames()
    {
        waitFrames = Mathf.FloorToInt((1 / firerate) * 30);
    }
}
