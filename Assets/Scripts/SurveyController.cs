using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurveyController : MonoBehaviour
{
    public Button button1, button2, button3, button4;                   //references to canvas buttons
    public int Q1Ans, Q2Ans, Q3Ans, Q4Ans, Q5Ans;                       //ints to store survey values
    public Text surveyText;                                             //reference to canvas text
    private bool btn1Press, btn2Press, btn3Press, btn4Press, question1, question2, question3, question4, question5;     //bools to control button presses and question timing
    public bool surveyComplete;                                         //bool to mark survey complete

    // Start is called before the first frame update
    void Start()
    {
        question1 = true;                       //sets bool to true
    }

    // Update is called once per frame
    void Update()
    {
        if (question1)              //if true....
        {
            Question1();            //call this function
        }
        if (question2)              //if true....
        {
            Question2();            //call this function
        }
        if (question3)              //if true.....
        {
            Question3();            //call this function
        }
        if (question4)              //if true.....
        {
            Question4();            //call this function
        }
        if (question5)              //if true....
        {
            Question5();            //call this function
        }

        button1.onClick.AddListener(Button1Press);      //looks for button press, then calls function
        button2.onClick.AddListener(Button2Press);      // ""
        button3.onClick.AddListener(Button3Press);      // ""
        button4.onClick.AddListener(Button4Press);      // ""
    }

    void Question1()
    {
        surveyText.text = "What do you think about this?";      //sets text value
        if (btn1Press)                                          //if this is true....
        {
            question1 = false;                  //sets bool to false
            Q1Ans = 1;                          //sets integer value
            btn1Press = false;                  //sets bool to false
            question2 = true;                   //sets bool to true
        }
        if (btn2Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;                  
            Q1Ans = 2;
            btn2Press = false;
            question2 = true;
        }
        if (btn3Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;
            Q1Ans = 3;
            btn3Press = false;
            question2 = true;
        }
        if (btn4Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;
            Q1Ans = 4;
            btn4Press = false;
            question2 = true;
        }
    }

    void Question2()                         //same as above function for different question/survey section
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

    void Question3()                         //same as above function for different question/survey section
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

    void Question4()                         //same as above function for different question/survey section
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

    void Question5()                         //same as above function for different question/survey section
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

    void Button1Press()             //when this function is called....
    {
        btn1Press = true;           //set bool to true
    }

    void Button2Press()             //same as above function 
    {
        btn2Press = true;
    }

    void Button3Press()             //same as above function 
    {
        btn3Press = true;
    }

    void Button4Press()             //same as above function 
    {
        btn4Press = true;
    }
}