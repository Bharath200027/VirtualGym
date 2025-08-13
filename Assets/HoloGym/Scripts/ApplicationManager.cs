using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

    public GameObject kinectManager;
    public GameObject avatarContoller;
    
    
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void playGame()
    {
        SceneManager.LoadScene("anim");
        SceneManager.UnloadSceneAsync("Menu 3D");
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Menu 3D");
        SceneManager.UnloadSceneAsync("anim");
    }

    public void mainGame()
    {
        Debug.Log("next");
        SceneManager.LoadScene("mainGame");
    }

    public void mainToHome()
    {
        colorChangeCanvas.fireballOn = false;

        score.soc = 0;

        touchGround.touchGnd = false;

        DestroyByWall.missedHit = false;
        DestroyByWall.missedhitball = 0;

        bulletFire.timer = 0.0f;
        bulletFire.fixtime = 30f;
        bulletFire.totaltime = 120f;
        bulletFire.remainingtime = 0f;
        bulletFire.startgame = false;
        
        Destroy(avatarContoller.GetComponent<AvatarController>());
        Destroy(kinectManager.GetComponent<KinectManager>());
        Destroy(kinectManager.GetComponent<KinectGestures>());
        Destroy(kinectManager.GetComponent<SimpleGestureListener>());

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

