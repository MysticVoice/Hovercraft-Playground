using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencedTargeting : TargetingMethod
{
    public List<TargetingMethod> targetingSequence;
    public override List<Transform> GetTargets(Transform user)
    {
        List<Transform> newTargets = new List<Transform>();
        for(int i = 0;i<targetingSequence.Count;i++)
        {
            if (i == 0) newTargets = targetingSequence[i].GetTargets(user);
            List<Transform> temp = new List<Transform>();
            foreach (Transform t in newTargets) temp.AddRange(targetingSequence[i].GetTargets(t));
            newTargets = temp;
        }
        return newTargets;
    }
}
