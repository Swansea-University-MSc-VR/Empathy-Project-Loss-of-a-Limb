using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Amazon;



public class Survey : MonoBehaviour
{
    

    public string IdentityPoolId = "";
    public string CognitoPoolRegion = Amazon.RegionEndpoint.EUWest2.SystemName;
    public string DynamoRegion = Amazon.RegionEndpoint.EUWest2.SystemName;
    public string dynamoTableName = "EGM130A1Empathy";
    public static Amazon.DynamoDBv2.DocumentModel.Table dynamoTable; 

    private RegionEndpoint _CognitoPoolRegion
    {
        get { return RegionEndpoint.GetBySystemName(CognitoPoolRegion); }
    }

    private RegionEndpoint _DynamoRegion
    {
        get { return RegionEndpoint.GetBySystemName(DynamoRegion); }
    }

    private static Amazon.DynamoDBv2.IAmazonDynamoDB _ddbClient;

    private Amazon.Runtime.AWSCredentials _credentials;

    private Amazon.Runtime.AWSCredentials Credentials
    {
        get
        {
            if (_credentials == null)
                _credentials = new Amazon.CognitoIdentity.CognitoAWSCredentials(IdentityPoolId, _CognitoPoolRegion);
            return _credentials;
        }
    }

    protected Amazon.DynamoDBv2.IAmazonDynamoDB Client
    {
        get
        {
            if (_ddbClient == null)
            {
                _ddbClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient(Credentials, _DynamoRegion);
            }

            return _ddbClient;
        }
    }


    [System.Serializable]
    public class QAndA
    {
        public string Question;
        public int Answer;
    } 
    [System.Serializable]

    public class SurveyData
    {
        public string Id; 
        // https://researcher-help.prolific.co/hc/en-gb/articles/360009220993-Recording-participants-Prolific-IDs-in-your-study-survey
        public string PROLIFIC_PID = "ID hasn't been set";
        public string STUDY_ID = "ID hasn't been set";
        public string SESSION_ID = "ID hasn't been set";
        public string timePreSurevyStart;
        public string timePreSurveyFinish;
        public string timePostSurevyStart;
        public string timePostSurveyFinish;
        

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
        UnityInitializer.AttachToGameObject(this.gameObject); // this starts AWS it has a terrible name! can only be one!
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest; // this use Http client useind the unity web requests

        // If there is no survey questions then Debug.Log error message, and then video 1 is launched 
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
        //  We will test to see what happens when there is no survey data 
        // This test to see if there is any survey data 
        if (surveyData.postExperimentSurvey == null)
        {
            Debug.LogError("There are no survey questions to load in the post test");
           // control.LaunchVideo2();
        }
        else
        {

            currentPostQuestion = surveyData.postExperimentSurvey[0];
            loadQuestionPre();
        }

        Debug.Log("starting Amazon dyanmo calls");


        Amazon.DynamoDBv2.DocumentModel.Table.LoadTableAsync(Client, dynamoTableName, (loadTableResult) =>
          {
              if (loadTableResult.Exception != null)
              {
                  Debug.LogError(" loadTableResultException" + loadTableResult.Exception);
              }
              else
              {
                  dynamoTable = loadTableResult.Result;
                  Debug.Log("loadTableResult.Result" + loadTableResult.Result);
              }
          }
        );

    }

    public void NextQuestionPre()
    {
        currentPreQuestionInt++;

        if (currentPreQuestionInt < surveyData.preExperimentSurvey.Count) 
        {
            currentPreQuestion = surveyData.preExperimentSurvey[currentPreQuestionInt];    
            loadQuestionPre();

            surveyData.timePreSurevyStart = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            Debug.Log("Time stamp for pre survey start");

        }
        else
        {
            surveyData.timePreSurveyFinish = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            Debug.Log("Time stamp for pre survey finished");
           // save();
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

            surveyData.timePostSurevyStart = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            Debug.Log("Time stamp for post survey start");
        }
        else
        {
            surveyData.timePostSurveyFinish = System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat);
            Debug.Log("Time stamp for post survey finish");
            save();
            control.LaunchVideo2();
            postSurveyComplete = true;
        }
    }
   

    void save()
    {
        // creating a uniquie identifier 
        string unhashedUniquieIdentifier = surveyData.PROLIFIC_PID + surveyData.SESSION_ID + surveyData.STUDY_ID + SystemInfo.deviceUniqueIdentifier + System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat); // This is a unique identifier 
        byte[] UniquieIDInBytes = System.Text.Encoding.UTF8.GetBytes(unhashedUniquieIdentifier);
        byte[] UniquieIDSHA512InBytes;

        // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha512?view=net-5.0
        // This line allows the protection of the persons computer by making the deviceUniqueIdentifier impossible to detect due to not being able to work out the time "The time is the salt" Salt Defn:https://en.wikipedia.org/wiki/Salt_(cryptography) 
        System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed();
        UniquieIDSHA512InBytes = shaM.ComputeHash(UniquieIDInBytes);
        string UniquieIDSHA512 = System.Text.Encoding.UTF8.GetString(UniquieIDSHA512InBytes);
        Debug.Log("UniquieIDSHA512 = " + UniquieIDSHA512);
        surveyData.Id = UniquieIDSHA512;

        // First section you create the json
        string surveyJson = JsonUtility.ToJson(surveyData);
        Debug.Log(surveyJson);

        // Save survey to a local  file 
        string path = Application.persistentDataPath + "/" + fileName + System.DateTime.Now.ToString(Amazon.Util.AWSSDKUtils.ISO8601BasicDateTimeFormat) + ".json";
        System.IO.File.WriteAllText(path,surveyJson);
        Debug.Log(path);

        // Saving it to AWS 
        // Takes the json data 
        var document = Amazon.DynamoDBv2.DocumentModel.Document.FromJson(surveyJson);

        if(dynamoTable != null)
        {
            dynamoTable.PutItemAsync(document, (result) =>
            {
                if (result.Exception != null)
                {
                    Debug.LogError("result.Exception" + result.Exception);
                }
                else
                {
                    Debug.Log("save to database");
                }
            });
        }
        else
        {
            Debug.LogError("failed to save to data base");
        }
      
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
