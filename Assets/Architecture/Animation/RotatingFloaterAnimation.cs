using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFloaterAnimation : MonoBehaviour
{
    public float floatHeight = 1;
    public float bobbingMagnitude = 0.3f;
    public float bobbingSpeed = 0.5f;
    public float rotationSpeed = 90;
    float randomOffset;
    public AnimationCurve bobbingCurve;

    // Start is called before the first frame update
    void Start()
    {
        randomOffset = Random.Range(0f,1f);
        transform.Rotate(transform.up,randomOffset*360);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, floatHeight+ (bobbingCurve.Evaluate(Mathf.Sin(((Time.time+randomOffset)) * bobbingSpeed) * bobbingSpeed))*bobbingMagnitude,0);
        transform.Rotate(transform.up,Time.deltaTime*rotationSpeed);
    }
}
