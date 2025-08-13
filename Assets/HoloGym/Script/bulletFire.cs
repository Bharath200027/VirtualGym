using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bulletFire : MonoBehaviour
{
    public GameObject theBullet;
    public Transform barrelEnd;

    public int bulletSpeed = 5;
    public float despawnTime = 5.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 2f;

    public static float timer = 0.0f;
    public static float fixtime = 30f;
    public static float totaltime = 120f;
    public static float remainingtime = 0f;

    public int timeLeft = 6;
    public TextMeshProUGUI countdownText;
    public Text timerText;
    public static bool startgame = false;

    void Start()
    {
        StartCoroutine("LoseTime");
        timerText.text = "Timer : 120";
        //countdownText.SetText("The Game starts in");

    }

    private void Update()
    {
        if(timeLeft >= -1)
        {
            countdownText.SetText(timeLeft.ToString());
            if(timeLeft == -1)
            {
                startgame = true;
                countdownText.enabled = false;
            } 
        }

        if (startgame)
        {
            remainingtime = totaltime - Mathf.RoundToInt(timer);
            timerText.text = "Timer : " + remainingtime;
            timer += Time.deltaTime;

            if (colorChangeCanvas.fireballOn)
            {
                if (timer > fixtime)
                {
                    bulletSpeed += 4;
                    fixtime += 30;
                }

                if (shootAble)
                {
                    shootAble = false;
                    Shoot();
                    StartCoroutine(ShootingYield());
                }
            }
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

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }   

    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, despawnTime); 
    }
}
