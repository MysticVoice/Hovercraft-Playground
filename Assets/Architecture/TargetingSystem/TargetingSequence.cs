using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Targeting Sequence", menuName = "Targeting System/Targeting Sequence")]

public class TargetingSequence : TargetingMethod
{
    public List<TargetingMethod> targetingSequence;

    public override List<Transform> GetTargets(Transform user)
    {
        List<Transform> result = new List<Transform>();
        result = targetingSequence[0].GetTargets(user);
        if (targetingSequence.Count > 1)
        {
            for (int i = 1; i < targetingSequence.Count; i++)
            {
                List<Transform> temp = new List<Transform>();
                foreach(Transform t in result)
                {
                    temp.AddRange(targetingSequence[i].GetTargets(t));
                }
                result = temp;
            }
        }
        return result;
    }
}
