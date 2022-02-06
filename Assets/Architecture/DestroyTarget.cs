using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public GameObject target;
    public void DestroyTargeted()
    {
        Destroy(target);
    }
}
