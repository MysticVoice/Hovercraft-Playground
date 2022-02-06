using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public float firerate;
    public GameObject projectile;
    public Transform[] FirePoints;
    public int currentFirePoint;
    public LayerMask whatIsTarget;
    public float nextFire;

    private void Start()
    {
        currentFirePoint = 0;
    }

    // Update is called once per frame
    override
    public void Fire(bool fire)
    {
        if (Time.time > nextFire)
        {
            GameObject p = Instantiate(projectile);
            p.GetComponent<DealDamage>().whatIsTarget = whatIsTarget;
            Transform firePoint = FirePoints[currentFirePoint];
            p.transform.position = firePoint.position;
            p.transform.rotation = firePoint.rotation;
            currentFirePoint++;
            currentFirePoint = currentFirePoint % FirePoints.Length;
            ResetFireTimer();
        }
    }

    public void ResetFireTimer()
    {
        nextFire = Time.time + (1 / firerate);
    }
}
