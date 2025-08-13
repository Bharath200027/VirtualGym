using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text text;
    public Text missedhitText;
    public static int soc = 0;

    public GameObject gameOver;

    private void Start()
    {
        text.text = "Score is : " + soc;
        gameOver.SetActive(false);
    }

    void Update()
    {
        text.text = "Score is : " + soc;
        if (touchGround.touchGnd && DestroyByWall.missedHit)
        {
            soc = soc + 10;
            touchGround.touchGnd = false;
            DestroyByWall.missedHit = false;
        }  
    }

    private void FixedUpdate()
    {
        if (bulletFire.timer >= 120)
        {
            bulletFire.startgame = false;
            colorChangeCanvas.fireballOn = false;
            gameOver.SetActive(true);
            missedhitText.text = "Your score is : " + soc;
        }
    }
}
