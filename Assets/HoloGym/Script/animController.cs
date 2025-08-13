using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    
    void Update()
    {
        if (score.soc == 50)
        {
            StartCoroutine("sittingClap");
        }
        else if (score.soc == 100)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 150)
        {
            StartCoroutine("sittingClap");
        }
        else if (score.soc == 200)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 250)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 300)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 350)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 400)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 450)
        {
            StartCoroutine("standingClap");
        }
        else if (score.soc == 500)
        {
            StartCoroutine("standingClap");
        }
    }

    IEnumerator sittingClap()
    {
        anim.SetBool("sittingClap", true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("sittingClap", false);
    }

    IEnumerator standingClap()
    {
        anim.SetBool("standingClap", true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("standingClap", false);
    }
}
