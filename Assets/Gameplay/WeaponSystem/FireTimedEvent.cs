using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireTimedEvent : MonoBehaviour, IFire
{
    private bool canFire = true;
    public UnityEvent OnFire = new UnityEvent();

    public void Fire()
    {
        if(canFire)
        {
            OnFire?.Invoke();
            DisableFire();
        }
    }

    public void ResetFire()
    {
        canFire = true;
    }
    public void DisableFire()
    {
        canFire = false;
    }
}
