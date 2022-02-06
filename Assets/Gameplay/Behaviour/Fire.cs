using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<Weapon> weapons;
    public GameObject projectile;
    public LayerMask whatIsTarget;

    public virtual void fire()
    {
        
        foreach(Weapon weapon in weapons)
        {
            weapon.Fire(true);
        }
    }
}
