using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInPlace : MonoBehaviour
{
    public GameObject spawnable;
    public void Spawn()
    {
        GameObject g = Instantiate(spawnable);
        g.transform.position = transform.position;
        g.transform.forward = -transform.up;
    }
}
