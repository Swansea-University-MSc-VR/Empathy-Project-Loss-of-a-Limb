using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandRecorder : MonoBehaviour
{

    public int[] surveyAnswers;

    [System.Serializable]
    public class WrappingClassTrack
    {
        public List<PointInTime> TrackRightController;
    }
    List<PointInTime> Track;
    // Start is called before the first frame update

    public bool save;
    public bool saveOnce;
    void Start()
    {
        Track = new List<PointInTime>();
        saveOnce = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (save)      
        {
            if (!saveOnce)
            {



                var variable = new WrappingClassTrack() { TrackRightController = Track };
                string debugTrack = JsonUtility.ToJson(variable);
                Debug.Log(debugTrack);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/RightControllerTrack.json", debugTrack);
                Debug.Log(Application.persistentDataPath + "/RightControllerTrack.json");
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
