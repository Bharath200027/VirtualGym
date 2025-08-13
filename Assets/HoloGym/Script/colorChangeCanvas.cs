using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangeCanvas : MonoBehaviour
{
    public Canvas red;
    public Canvas green;
    public static bool fireballOn = false;
    
    void Start()
    {
        red.enabled = false;
        green.enabled = true;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("gnd"))
        {
            red.enabled = false;
            green.enabled = true;
            fireballOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("gnd"))
        {
            red.enabled = true;
            green.enabled = false;
            fireballOn = false;
        }
    }
}
