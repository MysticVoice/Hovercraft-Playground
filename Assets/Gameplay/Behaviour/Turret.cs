using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{

    public Transform TurretXAxis;
    Vector3 dirrection;
    public Transform target;
    public float rotationSpeed = 2;
    public float rotationSpeedX = 0.1f;
    public Vector2 MinMaxRotation;
    public float projSpeed = 10;
    public bool useForwardAsRotationAxis = false;
    public bool predictLocation = true;
    public float threshold = 0.001f;

    private Rigidbody targetBody;
    private Vector3 predictedLocation;
    private Transform defaultAim;
    private float currRotX;
    public void SetTarget(Transform target)
    {
        this.target = target;
        targetBody = target.GetComponentInParent<Rigidbody>();
    }

    private void Start()
    {
        defaultAim = new GameObject().transform;
        defaultAim.name = "DefaultAim";
        defaultAim.parent = transform.parent;
        defaultAim.position = TurretXAxis.position + TurretXAxis.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PredictLocation();
        GetAimDirection();
        RotateTurret();
    }

    private void PredictLocation()
    {
        if (target != null)
        {
            if (targetBody != null && predictLocation) predictedLocation = TargetPredictor.PredictLocation(target.transform, targetBody, transform, projSpeed,false);
            else predictedLocation = target.transform.position;
        }
        else
        {
            predictedLocation = defaultAim.position;

        }
    }

    private void RotateTurret()
    {
        float leftRight = AngleDir(transform.forward, dirrection, transform.up);
        float angleDif = Vector3.Angle(dirrection, transform.forward);
        //transform.Rotate(transform.up, Mathf.Min(rotationSpeed * leftRight, angleDif));
        if(angleDif > threshold) transform.rotation = transform.rotation * Quaternion.Euler(0, Mathf.Min(rotationSpeed * leftRight, angleDif), 0);
        //Quaternion rot = Quaternion.Euler(dirrection);
        CalcXAxisTargetRotation();
    }

    private void GetAimDirection()
    {
        dirrection = (new Vector3(predictedLocation.x, transform.position.y, predictedLocation.z) - transform.position).normalized;
    }

    private void CalcXAxisTargetRotation()
    {
        Vector3 relativePos = transform.InverseTransformVector(predictedLocation)-transform.InverseTransformVector(TurretXAxis.position);
        //Vector3 relativePos = predictedLocation-TurretXAxis.position;
        float angleDif = Vector3.Angle(new Vector3(relativePos.x,0,relativePos.z), relativePos);
        if (angleDif > threshold)
        {
            if (relativePos.y > 0) angleDif = -angleDif;
            float relativeRotation = angleDif - currRotX;
            if (relativeRotation > rotationSpeed * 1.01f || relativeRotation < -rotationSpeed * 1.01f)
            {
                if (relativeRotation < 0) relativeRotation = Mathf.Max(relativeRotation, -rotationSpeedX);
                else relativeRotation = Mathf.Min(relativeRotation, rotationSpeedX);
                currRotX += relativeRotation;
                currRotX = Mathf.Clamp(currRotX, MinMaxRotation.x, MinMaxRotation.y);
                TurretXAxis.localRotation = Quaternion.Euler(currRotX, 0, 0);
            }
        }
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, predictedLocation);
    }
}
