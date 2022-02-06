using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateMouse : MonoBehaviour
{
    public enum MouseAxis {x,y,z}
    float rotation;
    float mouse;
    public bool flip = false;
    public float sens = 0.5f;
    public MouseAxis rotationAxis = MouseAxis.y;
    public InputActionReference rotInput;

    public void OnEnable()
    {
        rotInput.action.Enable();
    }
    public void OnDisable()
    {
        rotInput.action.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = rotInput.action.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        rotation += mouse * sens;
        Quaternion rot = transform.localRotation;
        float tempRot = rotation;
        if (flip) tempRot = -tempRot;
        switch (rotationAxis)
        {
            case MouseAxis.x:
            rot.eulerAngles = new Vector3(tempRot, 0, 0);
            break;
            case MouseAxis.y:
            rot.eulerAngles = new Vector3(0, tempRot, 0);
            break;
            case MouseAxis.z:
            rot.eulerAngles = new Vector3(0, 0, tempRot);
            break;
        }
        transform.localRotation = rot;
    }
}
