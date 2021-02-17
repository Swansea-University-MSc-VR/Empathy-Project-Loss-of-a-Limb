using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Survey2 : MonoBehaviour
{
    public SceneController control;
    public Question currentQuestion2;
    public Question[] questions2;
    public int[] answers2;
    public int currentQuestionInt2;
    public Text surveyText;
    public bool survey2Complete;



    // Start is called before the first frame update
    void Start()
    {
        currentQuestion2 = questions2[0];
        loadQuestion();
    }

    public void NextQuestion()
    {
        currentQuestionInt2++;

        if (currentQuestionInt2 < questions2.Length)
        {
            currentQuestion2 = questions2[currentQuestionInt2];
            loadQuestion();
        }
        else
        {
            save();
            survey2Complete = true;
            control.LaunchVideo2();
        }
    }

    void save()
    {
        string debugjson = JsonUtility.ToJson(answers2);
        Debug.Log(debugjson);
    }
    void loadQuestion()
    {
        surveyText.text = currentQuestion2.surveyQuestion;
    }

    public void buttonPress(int answer)
    {
        answers2[currentQuestionInt2] = answer;
        NextQuestion();
    }
}
