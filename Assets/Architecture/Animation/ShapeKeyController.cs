using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeKeyController : MonoBehaviour, IAnimate
{
    public SkinnedMeshRenderer[] targets;
    public AnimationCurve animation;
    public string[] keys;
    public float start = 0;
    public float end = 1;
    public float keyStart = 0;
    public float keyStop = 1;
    public bool invert = false;

    public void Animate(float state)
    {
        if (invert) state = Remap.map(state, 0, 1, 1, 0);
        if(state>=start && state<=end) RunAnimation(state);
    }

    public void RunAnimation(float time)
    {
        time = getLocalTime(time);
        time = animation.Evaluate(time);
        float state = time * 100;
        foreach (string s in keys)
        {
            foreach (SkinnedMeshRenderer target in targets)
            {
                int keyIndex = target.sharedMesh.GetBlendShapeIndex(s);
                target.SetBlendShapeWeight(keyIndex, state);
            }
        }
    }

    private float getLocalTime(float time)
    {
        return Mathf.Clamp(Remap.map(time,start,end,keyStart,keyStop),0,1);
    }
}
