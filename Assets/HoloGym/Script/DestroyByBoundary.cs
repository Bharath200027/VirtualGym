using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public GameObject fireExp;
    public Transform head;
    private bool exp = false;
    public float despawnTime = 5.0f;

    private void Update()
    {
        if (exp)
        {
            fire();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
            DestroyByWall.missedHit = false;
            exp = true;
        }
        
    }

    void fire()
    {
        var fireexp = Instantiate(fireExp, head.position, head.rotation);
        exp = false;
        Destroy(fireexp, despawnTime);
    }
}
