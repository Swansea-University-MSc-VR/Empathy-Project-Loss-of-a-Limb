using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public GameObject wheelChair, environment, playerModel, videoSphere;            //creates refeences for gameobjects
    public VideoPlayer VRVideo;                                                     //creates references for video player


    // Start is called before the first frame update
    void Start()
    {
        wheelChair.SetActive(false);                     //ensures gameobject is inactive
        environment.SetActive(false);                    //ensures gameobject is inactive
        playerModel.SetActive(false);                    //ensures gameobject is inactive
    }

    // Update is called once per frame
    void Update()
    {
        if (VRVideo.isPlaying != true)                  //if the video has finished playing....
        {
            LaunchEnvironment();                        //call funstion
        }
    }

    void LaunchEnvironment()
    {
        videoSphere.SetActive(false);                   //deactivates gameobject
        wheelChair.SetActive(true);                     //activate gameobject
        environment.SetActive(true);                    //activate gameobject
        playerModel.SetActive(true);                    //activate gameobject
    }
}
