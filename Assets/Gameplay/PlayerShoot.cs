using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private bool mouseClicked;
    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        if (mouseClicked)
        {
            GetComponent<Fire>().fire();
        }
    }

    public void CheckInput()
    {
        //mouseClicked = Input.GetMouseButton(0);
    }
}
