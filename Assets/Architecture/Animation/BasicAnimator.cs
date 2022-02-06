using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static MystLogic;

public class BasicAnimator : MonoBehaviour, IAnimate
{
    private IAnimate[] animations;
    public float animationLength = 1;
    private float startTime;
    bool animating = false;
    public bool playOnStartup = false;
    public bool currentDirection = true;
    public bool flipOnComplete = false;
    public bool continueWhenDone = false;
    public bool runInUpdate = true;
    private bool lastUpdate = false;
    public UnityEvent startAnimation = new UnityEvent();

    public void Awake()
    {
        animations = GetComponents<IAnimate>();
        if (playOnStartup)
        {
            animating = true;
            startTime = Time.time;
        }
    }

    [ContextMenu("Trigger Animation")]
    public void triggerAnimation()
    {
        animating = true;
        runInUpdate = true;
        startAnimation?.Invoke();
        SetStart();
    }

    public void Animate(float state)
    {
        state = Mathf.Clamp(state,0,1);
        if (InRange(state,0,1)||lastUpdate)
        {
            if (!InRange(state,0,1)) lastUpdate = false;
            else lastUpdate = true;
        }
        else
        {
            if (!continueWhenDone) animating = false;
            else SetStart();
            if (flipOnComplete) currentDirection = !currentDirection;
        }
        SetAnimationState(state);
    }

    public void SetAnimationState(float state)
    {
        foreach(IAnimate animation in animations)
        {
            if(animation != this) animation.Animate(state); //Ignore the warning, the self check is intentional
        }
    }

    private float getForwardTime()
    {
        return Remap.map(Time.time - startTime, 0, animationLength, 0, 1);
    }

    private float getReverseTime()
    {
        return Remap.map(Time.time - startTime, 0, animationLength, 1, 0);
    }

    private void Update()
    {
        if (animating && runInUpdate)
        {
            SelfRun();
        }
    }
    private void SelfRun()
    {
        float state;
        if (currentDirection) state = getForwardTime();
        else state = getReverseTime();
        Animate(state);
    }
    
    private void SetStart()
    {
        startTime = Time.time;
        lastUpdate = true;
    }
}
