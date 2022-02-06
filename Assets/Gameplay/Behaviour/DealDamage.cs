using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public LayerMask whatIsTarget;
    Collider[] targets;
    Health health;
    private Collider self;
    public int damage = 10;

    void Start()
    {
        self = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        targets = Physics.OverlapSphere(transform.position, transform.localScale.x/10,whatIsTarget);
        if(targets.Length>0 && targets[0] != self)
        {
            Collider target = targets[0];
            health = target.GetComponentInParent<Health>();
            if (health != null)
            {
                health.Decrease(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
