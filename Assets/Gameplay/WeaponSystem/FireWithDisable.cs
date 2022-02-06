using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityAtoms.BaseAtoms;

public class FireWithDisable : MonoBehaviour, IFire
{
    public BoolReference canFire;
    public UnityEvent OnFire = new UnityEvent();

    [ContextMenu("Fire")]
    public void Fire()
    {
        if(canFire.Value)
        {
            OnFire?.Invoke();
            DisableFire();
        }
    }

    [ContextMenu("Reload")]
    public void ResetFire()
    {
        canFire.Value = true;
    }
    public void DisableFire()
    {
        canFire.Value = false;
    }
}
