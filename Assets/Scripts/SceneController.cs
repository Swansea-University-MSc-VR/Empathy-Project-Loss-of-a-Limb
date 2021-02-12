using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public SurveyController surveyFinished;

    public GameObject wheelChair, environment, playerModel, videoSphere, surveyCanvas;            //creates refeences for gameobjects
    public VideoPlayer VRVideo1, VRVideo2;                                                     //creates references for video player
    public bool survey1Complete, survey2Complete;

    // Start is called before the first frame update
    void Start()
    {
        VRVideo1.Stop();
        VRVideo2.Stop();
        videoSphere.SetActive(false);
        wheelChair.SetActive(false);                     //ensures gameobject is inactive
        environment.SetActive(false);                    //ensures gameobject is inactive
        playerModel.SetActive(false);                    //ensures gameobject is inactive
        surveyCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (surveyFinished.surveyComplete)
        {
            videoSphere.SetActive(true);
            surveyCanvas.SetActive(false);
            VRVideo1.Play();
            survey1Complete = true;
        }

        if (VRVideo1.isPlaying != true && survey1Complete == true)                  //if the video has finished playing....
        {
            LaunchEnvironment();                        //call funstion
        }
    }

    void LaunchVideo1()
    {
        VRVideo1.Play();
        wheelChair.SetActive(false);                     //ensures gameobject is inactive
        environment.SetActive(false);                    //ensures gameobject is inactive
        playerModel.SetActive(false);                    //ensures gameobject is inactive
        surveyCanvas.SetActive(false);

    }

    void LaunchEnvironment()
    {
        videoSphere.SetActive(false);                   //deactivates gameobject
        wheelChair.SetActive(true);                     //activate gameobject
        environment.SetActive(true);                    //activate gameobject
        playerModel.SetActive(true);                    //activate gameobject
    }
}
