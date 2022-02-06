using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class TrackAndRotate : MonoBehaviour
{
    public Transform target;
    public bool invertX = false;
    public bool invertY = true;
    public bool invertZoom = true;
    public bool controlX = true;
    public bool alwaysActive = false;

    public float minZoom = 1;
    public float maxZoom = 20;
    public bool autoReset = true;
    public float resetRate = 0.01f;
    public float autoResetTime = 2;
    public float minY = 15;
    public float maxY = 70;
    public float resetY = 40;
    //public KeyCode resetCameraButton = KeyCode.Space;

    float zoom = 3;
    float xRot = 0;
    float yRot = 35;
    float autoResetTimer = 0;

    public float xSens = 1;
    public float ySens = 1;
    public float zoomSens = 1;

    void Update()
    {
        //RotationHandling();
        //CalcZoomValue(ref zoom, Input.mouseScrollDelta.y);
        transform.position = CalculateNewPosition(target,xRot,yRot);
    }

    private void RotationHandling()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool mouseButtonPressed = Input.GetMouseButton((int)MouseButton.RightMouse);
        if (mouseButtonPressed) autoResetTimer = Time.time + autoResetTime;
        if((autoReset && Time.time > autoResetTimer))
        {
            xRot = Mathf.Lerp(xRot, 0, resetRate);
            yRot = Mathf.Lerp(yRot, resetY, resetRate);
        }
        if(mouseButtonPressed||alwaysActive) GetRotationValues(ref xRot, ref yRot, mouseX, mouseY);
    }

    private Vector3 CalculateNewPosition(Transform target, float xRot, float yRot)
    {
        Vector3 targetPosition = -target.forward;
        targetPosition = Quaternion.AngleAxis(yRot, target.right) * targetPosition;
        targetPosition = Quaternion.AngleAxis(xRot, target.up) * targetPosition;
        targetPosition = targetPosition * zoom + target.position;
        return targetPosition;
    }

    private void GetRotationValues(ref float xRot, ref float yRot, float xInput, float yInput)
    {
        if(controlX)xRot = GetNewAxisValue(xRot, xInput, xSens, invertX);
        yRot = Mathf.Clamp(GetNewAxisValue(yRot, yInput, ySens, invertY),minY,maxY);
    }

    float GetNewAxisValue(float value, float input, float sensitivity, bool invert)
    {
        float result = (input * sensitivity);
        if (invert) result *= -1;
        return (value + result) % 360;
    }

    private void CalcZoomValue(ref float zoom,float input)
    {
        if (invertZoom) input *= -1;
        zoom += input * zoomSens;
        zoom = Mathf.Clamp(zoom,minZoom,maxZoom);
    }
}
