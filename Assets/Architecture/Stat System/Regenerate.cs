using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class Regenerate : MonoBehaviour
{
    public ConsumableStat stat;
    public FloatReference regenRate;
    private float regenCounter;
    // Update is called once per frame
    void FixedUpdate()
    {
        regenCounter += regenRate;
        if(regenCounter>=1)
        {
            int regenAmount = Mathf.FloorToInt(regenCounter);
            regenCounter -= regenAmount;
            stat.Increase(regenAmount);
        }
    }
}
