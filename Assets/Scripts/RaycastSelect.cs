using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelect : MonoBehaviour
{
    public float raycastRange;
    public Turret turret;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(ray,out hit,raycastRange))
        {
            Transform t = hit.collider.GetComponentInChildren<Transform>();
            if(t != null)
            {
                turret.SetTarget(t);
            }
        }
    }
}
