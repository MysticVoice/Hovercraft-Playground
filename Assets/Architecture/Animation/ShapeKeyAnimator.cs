using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class ShapeKeyAnimator : MonoBehaviour, IAnimate
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
    public FloatReference state;

    public void Awake()
    {
        animations = GetComponents<IAnimate>();
        if (playOnStartup)
        {
            animating = true;
            startTime = Time.time;
        }
    }
    public void Animate(float state)
    {
        float remappedState = Mathf.Clamp(this.state.Value,0,1);
        if (remappedState >= 1 && currentDirection || remappedState <= 0 && !currentDirection)
        {
            if (!continueWhenDone) animating = false;
            else SetStart();
            if (flipOnComplete) currentDirection = !currentDirection;
        }
        SetAnimationState(remappedState);
    }
    public void SetAnimationState(float state)
    {
        foreach(IAnimate animation in animations)
        {
            if(animation != this) animation.Animate(state);
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


    public void Update()
    {
        if (animating && runInUpdate)
        {
            float state;
            if (currentDirection) state = getForwardTime();
            else state = getReverseTime();
            Animate(state);
        }
    }

    [ContextMenu("Start Animation")]
    public void triggerAnimation()
    {
        animating = true;
        SetStart();
    }

    private void SetStart()
    {
        startTime = Time.time;
    }
}
