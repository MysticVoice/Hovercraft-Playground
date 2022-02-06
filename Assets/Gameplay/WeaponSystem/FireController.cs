using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireController : MonoBehaviour, IFire
{

    UnityEvent OnFire = new UnityEvent();
    public void Fire()
    {
        OnFire?.Invoke();
    }
}
