using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchGround : MonoBehaviour
{
    public static bool touchGnd = false;
    private bool upDown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!upDown)
        {
            if (other.gameObject.CompareTag("gnd"))
            {
                touchGnd = true;
                upDown = true;
            }
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (upDown)
        {
            touchGnd = false;
            upDown = false;
        } 
    }

}
