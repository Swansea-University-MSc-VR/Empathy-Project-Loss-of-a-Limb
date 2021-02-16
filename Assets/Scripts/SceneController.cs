using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Survey2 survey2Finished;                                                 //reference to surveyController script

    public GameObject wheelChair, environment, playerModel, video1Sphere, video2Sphere, survey1Canvas, survey2Canvas, welcomeCanvas, finishCanvas;      //creates refeences for gameobjects
    public VideoPlayer VRVideo1, VRVideo2;                                                  //creates references for video player
    public bool survey1Complete, survey2Complete, environmentComplete, restart, close;                                           //bools to control
    public Button next, replay, finish;


    void Start()
    {
        VRVideo1.Stop();                                        //ensures video not playing
        VRVideo2.Stop();                                        //ensures video is not playing
        video1Sphere.SetActive(false);                           //ensures game object inactive
        video2Sphere.SetActive(false);                           //ensures game object inactive
        wheelChair.SetActive(false);                            //ensures gameobject is inactive
        environment.SetActive(false);                           //ensures gameobject is inactive
        playerModel.SetActive(false);                           //ensures gameobject is inactive
        welcomeCanvas.SetActive(true);
        survey1Canvas.SetActive(false);                          //sets this game object to active
        survey2Canvas.SetActive(false);                         //sets this game object to inactive
        finishCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       

        next.onClick.AddListener(LaunchSurvey1);
        replay.onClick.AddListener(RestartBtn);
        finish.onClick.AddListener(Finish);

        if (VRVideo1.isPlaying != true && survey1Complete == true && survey2Complete == false)      //if the video has finished playing and survey is completed....
        {
            LaunchEnvironment();                                        //call funstion
        }
        if (environmentComplete && survey2Complete == false)
        {
            LaunchSurvey2();
        }
        if(VRVideo2.isPlaying != true && survey2Finished.survey2Complete)
        {
            LaunchFinishCanvas();
        }
        if (restart)
        {
            Replay();
        }
        if (close)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }

    void LaunchSurvey1()
    {
        welcomeCanvas.SetActive(false);
        survey1Canvas.SetActive(true);
    }

    public void LaunchVideo1()
    {
        video1Sphere.SetActive(true);                            //set gameobject to active
        VRVideo1.Play();                                        //play video file
        survey1Canvas.SetActive(false);                          //turn off survey canvas
        survey1Complete = true;                                 //set bool to true
    }

    void LaunchEnvironment()
    {
        video1Sphere.SetActive(false);                   //deactivates gameobject
        wheelChair.SetActive(true);                     //activate gameobject
        environment.SetActive(true);                    //activate gameobject
        playerModel.SetActive(true);                    //activate gameobject
    }

    void LaunchSurvey2()
    {
        wheelChair.SetActive(false);                    //ensures gameobject is inactive
        environment.SetActive(false);                   //ensures gameobject is inactive
        playerModel.SetActive(false);                   //ensures gameobject is inactive
        survey2Canvas.SetActive(true);                   //sets this game object to active
    }

    public void LaunchVideo2()
    {
        survey2Canvas.SetActive(false);                  //turn off survey canvas
        video2Sphere.SetActive(true);                    //set gameobject to active
        VRVideo2.Play();                                //play video file
        survey2Complete = true;

    }

    void LaunchFinishCanvas()
    {
        video2Sphere.SetActive(false);
        finishCanvas.SetActive(true);
    }

    void RestartBtn()
    {
        restart = true;
    }
    
    void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Finish()
    {
        close = true;
    }
}
