using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MystLogic;
using UnityAtoms.BaseAtoms;

public class ConstrainedAnimator : MonoBehaviour, IAnimate
{
    public SkinnedMeshRenderer[] targets;
    public AnimationCurve animation;
    public string[] keys;
    public float start = 0;
    public float end = 1;
    public float keyStart = 0;
    public float keyStop = 1;
    public bool invert = false;
    private bool lastUpdate = false;
    public FloatReference state;
    public void Animate(float state)
    {
        float remappedState = this.state;
        if (invert) remappedState = Remap.map(this.state.Value, 0, 1, 1, 0);
        if ((InRange(remappedState,start,end)) || lastUpdate)
        {
            if (!InRange(remappedState,start,end)) lastUpdate = false;
            else lastUpdate = true;
            RunAnimation(remappedState);
        }
    }

    public void RunAnimation(float state)
    {
        state = getLocalState(state);
        state = animation.Evaluate(state);
        state = state * 100;
        foreach (string s in keys)
        {
            foreach (SkinnedMeshRenderer target in targets)
            {
                int keyIndex = target.sharedMesh.GetBlendShapeIndex(s);
                target.SetBlendShapeWeight(keyIndex, state);
            }
        }
    }

    private float getLocalState(float state)
    {
        return Mathf.Clamp(Remap.map(state,start,end,keyStart,keyStop),0,1);
    }
}
