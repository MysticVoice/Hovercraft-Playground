using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireEventOnFire : MonoBehaviour, IFire
{

    public UnityEvent OnFire = new UnityEvent();
    [ContextMenu("Fire")]
    public void Fire()
    {
        OnFire?.Invoke();
    }
}
