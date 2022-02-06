using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsOn : MonoBehaviour
{
    public UnityEvent OnTriggered = new UnityEvent();
    public UnityEvent OffTriggered = new UnityEvent();
    public bool isOn = false;
    public void CheckOn()
    {
        if (isOn) OnTriggered?.Invoke();
        else OffTriggered?.Invoke();
    }
    public void TurnOn()
    {
        isOn = true;
    }
    public void TurnOff()
    {
        isOn = false;
    }
    public void Toggle()
    {
        isOn = !isOn;
    }
}
