using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animation_instructor : MonoBehaviour
{
    public Animator anim;

    public GameObject theBullet;
    public Transform barrelEnd;

    public int bulletSpeed = 5;
    public float despawnTime = 5.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 2f;
    public static float animtimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animtimer += Time.deltaTime;

        if(animtimer >= 7f && animtimer < 38f)
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }

        else if(animtimer >= 38f && animtimer < 41f)
        {
            shootAble = false;
        }

        else if (animtimer >= 41f)
        {
            SceneManager.LoadScene("mainGame");
        }


    }

    IEnumerator ShootingYield()
    {
        if (!shootAble)
        {
            yield return new WaitForSeconds(waitBeforeNextShot);
            shootAble = true;
        }

    }

    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, despawnTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Anim");
    }

    IEnumerator Anim()
    {
        anim.SetBool("isSquat", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isSquat", false);
    }
}
