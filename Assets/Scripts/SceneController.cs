using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    //public Survey surveyFinished;                                                 //reference to surveyController script

    public GameObject wheelChair, environment, playerModel, videoSphere, survey1Canvas, survey2Canvas;      //creates refeences for gameobjects
    public VideoPlayer VRVideo1, VRVideo2;                                                  //creates references for video player
    public bool survey1Complete, survey2Complete, environmentComplete;                                           //bools to control

    void Start()
    {
        VRVideo1.Stop();                                        //ensures video not playing
        VRVideo2.Stop();                                        //ensures video is not playing
        videoSphere.SetActive(false);                           //ensures game object inactive
        wheelChair.SetActive(false);                            //ensures gameobject is inactive
        environment.SetActive(false);                           //ensures gameobject is inactive
        playerModel.SetActive(false);                           //ensures gameobject is inactive
        survey1Canvas.SetActive(true);                          //sets this game object to active
        survey2Canvas.SetActive(false);                         //sets this game object to inactive

    }

    // Update is called once per frame
    void Update()
    {
        if (VRVideo1.isPlaying != true && survey1Complete == true)      //if the video has finished playing and survey is completed....
        {
            LaunchEnvironment();                                        //call funstion
        }
        if (environmentComplete)
        {
            LaunchSurvey2();
        }

    }

    public void LaunchVideo1()
    {
        videoSphere.SetActive(true);                            //set gameobject to active
        VRVideo1.Play();                                        //play video file
        wheelChair.SetActive(false);                            //ensures gameobject is inactive
        environment.SetActive(false);                           //ensures gameobject is inactive
        playerModel.SetActive(false);                           //ensures gameobject is inactive
        survey1Canvas.SetActive(false);                          //turn off survey canvas
        survey2Canvas.SetActive(false);
        survey1Complete = true;                                 //set bool to true

    }

    void LaunchEnvironment()
    {
        videoSphere.SetActive(false);                   //deactivates gameobject
        wheelChair.SetActive(true);                     //activate gameobject
        environment.SetActive(true);                    //activate gameobject
        playerModel.SetActive(true);                    //activate gameobject
    }

    void LaunchSurvey2()
    {
        VRVideo1.Stop();                                //ensures video not playing
        VRVideo2.Stop();                                //ensures video is not playing
        videoSphere.SetActive(false);                   //ensures game object inactive
        wheelChair.SetActive(false);                    //ensures gameobject is inactive
        environment.SetActive(false);                   //ensures gameobject is inactive
        playerModel.SetActive(false);                   //ensures gameobject is inactive
        survey2Canvas.SetActive(true);                   //sets this game object to active
    }

    public void LaunchVideo2()
    {
        videoSphere.SetActive(true);                    //set gameobject to active
        VRVideo1.Play();                                //play video file
        wheelChair.SetActive(false);                    //ensures gameobject is inactive
        environment.SetActive(false);                   //ensures gameobject is inactive
        playerModel.SetActive(false);                   //ensures gameobject is inactive
        survey1Canvas.SetActive(false);                  //turn off survey canvas
        survey2Canvas.SetActive(false);                  //turn off survey canvas
    }
}
