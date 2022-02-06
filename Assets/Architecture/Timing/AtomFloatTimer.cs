using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityAtoms.BaseAtoms;

public class AtomFloatTimer : MonoBehaviour
{
    public FloatReference duration;
    public BoolReference timerRunning;
    public FloatReference referencedTime;
    public FloatReference time;
    public BoolReference flipTimer;
    public BoolReference flipOnComplete;
    public BoolReference continueWhenDone;
    public BoolReference pauseTimer;
    public UnityEvent timerElapsed;

    [ContextMenu("StartTimer")]
    public void StartTimer()
    {
        timerRunning.Value = true;
        referencedTime.Value = Time.time;
    }

    public float CheckTimer()
    {
        if(!flipTimer)return Remap.map(Time.time - referencedTime, 0, duration, 0, 1);
        else return Remap.map(Time.time - referencedTime, 0, duration, 1, 0);
    }

    private void FixedUpdate()
    {
        if (timerRunning)
        {
            if (!pauseTimer.Value) UpdateTimer();
            else referencedTime.Value += Time.deltaTime;

        }
    }

    private void UpdateTimer()
    {
        time.Value = CheckTimer();
        if ((!flipTimer&&time.Value > 1)||(flipTimer&&time.Value<0))
        {
            SetEndState();
        }
    }

    private void SetEndState()
    {
        if (!continueWhenDone.Value) timerRunning.Value = false;
        else StartTimer();
        if(!flipTimer) time.Value = 1;
        else time.Value = 0;
        if (flipOnComplete.Value) flipTimer.Value = !flipTimer.Value;
        timerElapsed?.Invoke();
    }
}
