using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
  //  public Survey surveyData;
  //  public Survey2 survey2Data;
  //  public SceneController saveTime;

    public int[] surveyAnswers;

    [System.Serializable]
    public class WrappingClassTrack
    {
        public List<PointInTime> TrackMainCamera;
    }
    List<PointInTime> Track;
    // Start is called before the first frame update

    public bool save;
    public bool saveOnce;
    public string fileName = "TrackMainCamera"; 
    void Start()
    {
        Track = new List<PointInTime>();
        saveOnce = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (save) //Time.save)           //change to if (saveTime) to active from SceneController
        {
            if (!saveOnce)
            {
               /* surveyAnswers[0] = surveyData.answers[0];
                surveyAnswers[1] = surveyData.answers[1];
                surveyAnswers[2] = surveyData.answers[2];
                surveyAnswers[3] = surveyData.answers[3];
                surveyAnswers[4] = surveyData.answers[4];
                surveyAnswers[5] = surveyData.answers[5];
                surveyAnswers[6] = surveyData.answers[6];
                surveyAnswers[7] = surveyData.answers[7];
                surveyAnswers[8] = survey2Data.answers2[0];
                surveyAnswers[9] = survey2Data.answers2[1];
                surveyAnswers[10] = survey2Data.answers2[2];
                surveyAnswers[11] = survey2Data.answers2[3]; */


                var variable = new WrappingClassTrack() { TrackMainCamera = Track };
                string debugTrack = JsonUtility.ToJson(variable);
                Debug.Log(debugTrack);
                string path = Application.persistentDataPath + "/" + fileName + System.DateTime.Now.ToString("yyyy''MM''dd'T'HH'mm'ss") + ".json";
                System.IO.File.WriteAllText(Application.persistentDataPath + "/MainCameraTrack.json", debugTrack); 
                Debug.Log(Application.persistentDataPath + "/MainCameraTrack.json");
                saveOnce = true; 
            }

        }
        else
        {
          var pointInTime = new PointInTime(Time.time, this.transform.position, this.transform.rotation);
          // string debugPointInTime = JsonUtility.ToJson(pointInTime);
          // Debug.Log(debugPointInTime); 
          Track.Add(pointInTime);
            saveOnce = false; 
        }  
    }
}
