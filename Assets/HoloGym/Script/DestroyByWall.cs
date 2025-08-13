using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByWall : MonoBehaviour
{
    public static int missedhitball = 0;
    public static bool missedHit = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            missedhitball++;
            missedHit = true;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
        }
    }
}
