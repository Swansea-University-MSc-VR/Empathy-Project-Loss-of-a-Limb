using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Survey survey2Finished;                                                                                                                          //reference to surveyController script

    public GameObject XRRig, XRRig3, wheelChair, environment, video1Sphere, video2Sphere, survey1Canvas, survey2Canvas, welcomeCanvas, finishCanvas;        //creates refeences for gameobjects
    public VideoPlayer VRVideo1, VRVideo2;                                                                                                                  //creates references for video player
    public bool survey1Complete, survey2Complete, environmentComplete, restart, close, Vid2Played;                                                          //bools to control
    public Button next, replay, finish;


    void Start()
    {
        VRVideo1.Stop();                                //ensures video not playing
        VRVideo2.Stop();                                //ensures video is not playing
        video1Sphere.SetActive(false);                  //ensures game object inactive
        video2Sphere.SetActive(false);                  //ensures game object inactive
        wheelChair.SetActive(false);                    //ensures gameobject is inactive
        environment.SetActive(false);                   //ensures gameobject is inactive
        welcomeCanvas.SetActive(true);                  //sets this game object to active
        survey1Canvas.SetActive(false);                 //sets this game object to active
        survey2Canvas.SetActive(false);                 //sets this game object to inactive
        finishCanvas.SetActive(false);                  //sets this game object to inactive
        XRRig.SetActive(true);                          //sets this game object to active
        Vid2Played = false;                             //sets bool false
    }

    // Update is called once per frame
    void Update()
    {       
        next.onClick.AddListener(LaunchSurvey1);
        replay.onClick.AddListener(RestartBtn);
        finish.onClick.AddListener(Finish);

        if (VRVideo1.isPlaying != true && survey1Complete == true && survey2Complete == false)      //if the video has finished playing and survey is completed....
        {
            LaunchEnvironment();                                                                    //call funstion
        }
        if (environmentComplete && survey2Finished.postSurveyComplete == false)                     //if this condition is met....
        {
            LaunchSurvey2();                                                                        //call this function
        }
        if(environmentComplete && survey2Finished.postSurveyComplete)                               //if this condition is met....
        {
            LaunchVideo2();                                                                         //call this function
        }
        if(VRVideo2.isPlaying != true && survey2Finished.postSurveyComplete && Vid2Played)          //if this condition is met....
        {
            LaunchFinishCanvas();                                                                   //call this function
        }
        if (restart)                                                                                //uf this condition is met.....
        {
            Replay();                                                                               //call this function
        }
        if (close)                                                                                  //if this condition is met....
        {
            //UnityEditor.EditorApplication.isPlaying = false;                                      //stop editor playback
            Application.Quit();                                                                     //close application
        }

    }

    void LaunchSurvey1()
    {
        welcomeCanvas.SetActive(false);                     //turns off GO
        survey1Canvas.SetActive(true);                      //turns on GO
        XRRig.SetActive(true);                              //turns on GO
    }

    public void LaunchVideo1()
    {
        video1Sphere.SetActive(true);                       //set gameobject to active
        VRVideo1.Play();                                    //play video file
        survey1Canvas.SetActive(false);                     //turn off survey canvas
        survey1Complete = true;                             //set bool to true
        XRRig.SetActive(true);                              //turns on GO

    }

    void LaunchEnvironment()
    {
        video1Sphere.SetActive(false);                      //deactivates gameobject
        wheelChair.SetActive(true);                         //activate gameobject
        environment.SetActive(true);                        //activate gameobject
        XRRig.SetActive(false);                             //turns off GO

    }

    void LaunchSurvey2()
    {
        wheelChair.SetActive(false);                        //ensures gameobject is inactive
        environment.SetActive(false);                       //ensures gameobject is inactive
        survey2Canvas.SetActive(true);                      //sets this game object to active
        XRRig3.SetActive(true);                             //turns on GO

    }

    public void LaunchVideo2()
    {
        survey2Canvas.SetActive(false);                     //turn off survey canvas
        video2Sphere.SetActive(true);                       //set gameobject to active
        VRVideo2.Play();                                    //play video file
        survey2Complete = true;                             //sets bool true
        XRRig3.SetActive(true);                             //turns on GO
        Vid2Played = true;                                  //sets bool true
    }

    void LaunchFinishCanvas()
    {
        video2Sphere.SetActive(false);                      //turns off GO
        finishCanvas.SetActive(true);                       //turns on GO
        XRRig3.SetActive(true);                             //turns on GO
                
    }

    void RestartBtn()
    {
        restart = true;                                     //sets bool true
    }
    
    void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //reloads currently loaded scene
    }

    void Finish()
    {
        close = true;                                       //sets bool true
    }
}
