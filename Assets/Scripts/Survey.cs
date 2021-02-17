using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Survey : MonoBehaviour
{
    

    [System.Serializable]
    public class QAndA
    {
        public string Question;
        public int Answer;
    } 
    [System.Serializable]

    public class SurveyData
    {
        // https://researcher-help.prolific.co/hc/en-gb/articles/360009220993-Recording-participants-Prolific-IDs-in-your-study-survey
        public string PROLIFIC_PID = "ID hasn't been set";
        public string STUDY_ID = "ID hasn't been set";
        public string SESSION_ID = "ID hasn't been set";
        public string timePre;
        public string timePost;

        public List<QAndA> preExperimentSurvey;
        public List<QAndA> postExperimentSurvey;
        

    }

    public SurveyData surveyData = new SurveyData();

    public SceneController control;
    public QAndA currentPreQuestion;
    public int currentPreQuestionInt;
    public Text preSurveyText;
    public bool preSurveyComplete;
    
    public QAndA currentPostQuestion;
    public int currentPostQuestionInt;
    public Text postSurveyText;
    public bool postSurveyComplete;

    public string fileName; 

    // Start is called before the first frame update
    void Start()
    {
        if (surveyData.preExperimentSurvey == null)
        {
            Debug.LogError("There are no survey questions to load in the pre test");
            control.LaunchVideo1();

        }
        else
        {
            currentPreQuestion = surveyData.preExperimentSurvey[0];
            loadQuestionPre();
        }
        if (surveyData.postExperimentSurvey == null)
        {
            Debug.LogError("There are no survey questions to load in the post test");
            control.LaunchVideo2();
        }
        else
        {

            currentPostQuestion = surveyData.postExperimentSurvey[0];
            loadQuestionPre();
        }

    }

    public void NextQuestionPre()
    {
        currentPreQuestionInt++;

        if (currentPreQuestionInt < surveyData.preExperimentSurvey.Count) 
        {
            currentPreQuestion = surveyData.preExperimentSurvey[currentPreQuestionInt];
            loadQuestionPre();
        }
        else
        {
            surveyData.timePre = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            save();
            control.LaunchVideo1();
            preSurveyComplete = true;
        }
    }
    public void NextQuestionPost()
    {
        currentPostQuestionInt++;

        if (currentPostQuestionInt < surveyData.postExperimentSurvey.Count)
        {
            currentPostQuestion = surveyData.postExperimentSurvey[currentPostQuestionInt];
            loadQuestionPost();
        }
        else
        {
            surveyData.timePost = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            save();
            control.LaunchVideo2();
            postSurveyComplete = true;
        }
    }
    void save()
    {
       string debugjson = JsonUtility.ToJson(surveyData);
        Debug.Log(debugjson);
        string path = Application.persistentDataPath + "/" + fileName + System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat) + ".json";
        System.IO.File.WriteAllText(path,debugjson);
        Debug.Log(path);
    }

    void loadQuestionPre()
    {
        preSurveyText.text = currentPreQuestion.Question;
    }
    void loadQuestionPost()
    {
        postSurveyText.text = currentPostQuestion.Question;
    }
    public void preButtonPress(int answer)
    {
        surveyData.preExperimentSurvey[currentPreQuestionInt].Answer = answer;
        NextQuestionPre();
    }
    public void postButtonPress(int answer)
    {
        surveyData.postExperimentSurvey[currentPostQuestionInt].Answer = answer;
        NextQuestionPost();
    }
}
