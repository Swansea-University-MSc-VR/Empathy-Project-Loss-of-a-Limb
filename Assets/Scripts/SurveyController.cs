using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurveyController : MonoBehaviour
{
    public Button button1, button2, button3, button4;
    public int Q1Ans, Q2Ans, Q3Ans, Q4Ans, Q5Ans;
    public Text surveyText;
    public bool btn1Press, btn2Press, btn3Press, btn4Press, surveyComplete, question1, question2, question3, question4, question5;

    // Start is called before the first frame update
    void Start()
    {
        question1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (question1)
        {
            Question1();
        }
        if (question2)
        {
            Question2();
        }
        if (question3)
        {
            Question3();
        }
        if (question4)
        {
            Question4();
        }
        if (question5)
        {
            Question5();
        }

        button1.onClick.AddListener(Button1Press);
        button2.onClick.AddListener(Button2Press);
        button3.onClick.AddListener(Button3Press);
        button4.onClick.AddListener(Button4Press);
    }

    void Question1()
    {
        surveyText.text = "What do you think about this?";
        if (btn1Press)
        {
            question1 = false;
            Q1Ans = 1;
            btn1Press = false;
            question2 = true;         
        }
        if (btn2Press)
        {
            question1 = false;
            Q1Ans = 2;
            btn2Press = false;
            question2 = true;
        }
        if (btn3Press)
        {
            question1 = false;
            Q1Ans = 3;
            btn3Press = false;
            question2 = true;
        }
        if (btn4Press)
        {
            question1 = false;
            Q1Ans = 4;
            btn4Press = false;
            question2 = true;
        }
    }

    void Question2()
    {
        surveyText.text = "Are you sure?";
        if (btn1Press)
        {
            question2 = false;
            Q2Ans = 1;
            btn1Press = false;
            question3 = true;
        }
        if (btn2Press)
        {
            question2 = false;
            Q2Ans = 2;
            btn2Press = false;
            question3 = true;
        }
        if (btn3Press)
        {
            question2 = false;
            Q2Ans = 3;
            btn3Press = false;
            question3 = true;
        }
        if (btn4Press)
        {
            question2 = false;
            Q2Ans = 4;
            btn4Press = false;
            question3 = true;
        }
    }

    void Question3()
    {
        surveyText.text = "Can you be more specific?";
        if (btn1Press)
        {
            question3 = false;
            Q3Ans = 1;
            btn1Press = false;
            question4 = true;
        }
        if (btn2Press)
        {
            question3 = false;
            Q3Ans = 2;
            btn2Press = false;
            question4 = true;
        }
        if (btn3Press)
        {
            question3 = false;
            Q3Ans = 3;
            btn3Press = false;
            question4 = true;
        }
        if (btn4Press)
        {
            question3 = false;
            Q3Ans = 4;
            btn4Press = false;
            question4 = true;
        }
    }

    void Question4()
    {
        surveyText.text = "Can you be less specific";
        if (btn1Press)
        {
            question4 = false;
            Q4Ans = 1;
            btn1Press = false;
            question5 = true;
        }
        if (btn2Press)
        {
            question4 = false;
            Q4Ans = 2;
            btn2Press = false;
            question5 = true;
        }
        if (btn3Press)
        {
            question4 = false;
            Q4Ans = 3;
            btn3Press = false;
            question5 = true;
        }
        if (btn4Press)
        {
            question4 = false;
            Q4Ans = 4;
            btn4Press = false;
            question5 = true;
        }
    }

    void Question5()
    {
        surveyText.text = "What is time?";
        if (btn1Press)
        {
            Q5Ans = 1;
            btn1Press = false;
            surveyComplete = true;

        }
        if (btn2Press)
        {
            Q5Ans = 2;
            btn2Press = false;
            surveyComplete = true;

        }
        if (btn3Press)
        {
            Q5Ans = 3;
            btn3Press = false;
            surveyComplete = true;

        }
        if (btn4Press)
        {
            Q5Ans = 4;
            btn4Press = false;
            surveyComplete = true;
        }
    }

    void Button1Press()
    {
        btn1Press = true;
    }

    void Button2Press()
    {
        btn2Press = true;
    }

    void Button3Press()
    {
        btn3Press = true;
    }

    void Button4Press()
    {
        btn4Press = true;
    }
}