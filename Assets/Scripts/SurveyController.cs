using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurveyController : MonoBehaviour
{
    public Button button1, button2, button3, button4, button5;                      //references to canvas buttons
    public int Q1Ans, Q2Ans, Q3Ans, Q4Ans, Q5Ans, Q6Ans, Q7Ans, Q8Ans, totalScore;              //ints to store survey values
    public Text surveyText;                                                         //reference to canvas text
    private bool btn1Press, btn2Press, btn3Press, btn4Press, btn5Press, question1, question2, question3, question4, question5, question6, question7, question8;     //bools to control button presses and question timing
    public bool surveyComplete;                                                     //bool to mark survey complete

    // Start is called before the first frame update
    void Start()
    {
        question1 = true;           //sets bool to true
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
        if (question6)              //if true...
        {
            Question6();            //call this function
        }
        if (question7)              //if true....
        {
            Question7();            //call this function
        }
        if (question8)              //if true....
        {
            Question8();            //call this function
        }

        button1.onClick.AddListener(Button1Press);      //looks for button press, then calls function
        button2.onClick.AddListener(Button2Press);      // ""
        button3.onClick.AddListener(Button3Press);      // ""
        button4.onClick.AddListener(Button4Press);      // ""
        button5.onClick.AddListener(Button5Press);      // ""

    }

    void Question1()
    {
        surveyText.text = "I daydream and fantasize, with some regularity, about things that might happen to me.";      //sets text value
        
        if (btn1Press)                          //if this is true....
        {
            question1 = false;                  //sets bool to false
            Q1Ans = 0;                          //sets integer value
            btn1Press = false;                  //sets bool to false
            question2 = true;                   //sets bool to true
        }
        if (btn2Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;                  
            Q1Ans = 1;
            btn2Press = false;
            question2 = true;
        }
        if (btn3Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;
            Q1Ans = 2;
            btn3Press = false;
            question2 = true;
        }
        if (btn4Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;
            Q1Ans = 3;
            btn4Press = false;
            question2 = true;
        }
        if (btn5Press)                          //same as above 'if' statement for different bool
        {
            question1 = false;
            Q1Ans = 4;
            btn5Press = false;
            question2 = true;
        }
    }

    void Question2()                         //same as above function for different question/survey section
    {
        surveyText.text = "I often have tender, concerned feelings for people less fortunate than me.";
        if (btn1Press)
        {
            question2 = false;
            Q2Ans = 0;
            btn1Press = false;
            question3 = true;
        }
        if (btn2Press)
        {
            question2 = false;
            Q2Ans = 1;
            btn2Press = false;
            question3 = true;
        }
        if (btn3Press)
        {
            question2 = false;
            Q2Ans = 2;
            btn3Press = false;
            question3 = true;
        }
        if (btn4Press)
        {
            question2 = false;
            Q2Ans = 3;
            btn4Press = false;
            question3 = true;
        }
        if (btn5Press)
        {
            question2 = false;
            Q2Ans = 4;
            btn5Press = false;
            question3 = true;
        }
    }

    void Question3()                         //same as above function for different question/survey section
    {
        surveyText.text = "I sometimes find it difficult to see things from the 'other guy's' point of view.";
        if (btn1Press)
        {
            question3 = false;
            Q3Ans = 0;
            btn1Press = false;
            question4 = true;
        }
        if (btn2Press)
        {
            question3 = false;
            Q3Ans = 1;
            btn2Press = false;
            question4 = true;
        }
        if (btn3Press)
        {
            question3 = false;
            Q3Ans = 2;
            btn3Press = false;
            question4 = true;
        }
        if (btn4Press)
        {
            question3 = false;
            Q3Ans = 3;
            btn4Press = false;
            question4 = true;
        }
        if (btn5Press)
        {
            question3 = false;
            Q3Ans = 4;
            btn5Press = false;
            question4 = true;
        }
    }

    void Question4()                         //same as above function for different question/survey section
    {
        surveyText.text = "Sometimes I don't feel very sorry for other people when they are having problems.";
        if (btn1Press)
        {
            question4 = false;
            Q4Ans = 0;
            btn1Press = false;
            question5 = true;
        }
        if (btn2Press)
        {
            question4 = false;
            Q4Ans = 1;
            btn2Press = false;
            question5 = true;
        }
        if (btn3Press)
        {
            question4 = false;
            Q4Ans = 2;
            btn3Press = false;
            question5 = true;
        }
        if (btn4Press)
        {
            question4 = false;
            Q4Ans = 3;
            btn4Press = false;
            question5 = true;
        }
        if (btn5Press)
        {
            question4 = false;
            Q4Ans = 4;
            btn5Press = false;
            question5 = true;
        }
    }

    void Question5()                         //same as above function for different question/survey section
    {
        surveyText.text = "I really get involved with the feelings of the characters in a novel.";
        if (btn1Press)
        {
            Q5Ans = 0;
            btn1Press = false;
            question5 = false;
            question6 = true;

        }
        if (btn2Press)
        {
            Q5Ans = 1;
            btn2Press = false;
            question5 = false;
            question6 = true;
        }
        if (btn3Press)
        {
            Q5Ans = 2;
            btn3Press = false;
            question5 = false;
            question6 = true;
        }
        if (btn4Press)
        {
            Q5Ans = 3;
            btn4Press = false;
            question5 = false;
            question6 = true;
        }
        if (btn5Press)
        {
            Q5Ans = 4;
            btn5Press = false;
            question5 = false;
            question6 = true;
        }
    }

    void Question6()                         //same as above function for different question/survey section
    {
        surveyText.text = "In emergency situations, I feel apprehensive and ill-at-ease.";
        if (btn1Press)
        {
            Q6Ans = 0;
            btn1Press = false;
            question6 = false;
            question7 = true;
        }
        if (btn2Press)
        {
            Q6Ans = 1;
            btn2Press = false;
            question6 = false;
            question7 = true;
        }
        if (btn3Press)
        {
            Q6Ans = 2;
            btn3Press = false;
            question6 = false;
            question7 = true;
        }
        if (btn4Press)
        {
            Q6Ans = 3;
            btn4Press = false;
            question6 = false;
            question7 = true;
        }
        if (btn5Press)
        {
            Q6Ans = 4;
            btn5Press = false;
            question6 = false;
            question7 = true;
        }
    }

    void Question7()                         //same as above function for different question/survey section
    {
        surveyText.text = "I am usually objective when I watch a movie or play, and I don't often get completely caught up in it.";
        if (btn1Press)
        {
            Q7Ans = 0;
            btn1Press = false;
            question7 = false;
            question8 = true;
        }
        if (btn2Press)
        {
            Q7Ans = 1;
            btn2Press = false;
            question7 = false;
            question8 = true;
        }
        if (btn3Press)
        {
            Q7Ans = 2;
            btn3Press = false;
            question7 = false;
            question8 = true;
        }
        if (btn4Press)
        {
            Q7Ans = 3;
            btn4Press = false;
            question7 = false;
            question8 = true;
        }
        if (btn5Press)
        {
            Q7Ans = 4;
            btn5Press = false;
            question7 = false;
            question8 = true;
        }
    }

    void Question8()                         //same as above function for different question/survey section
    {
        surveyText.text = "I try to look at everybody's side of a disagreement before I make a decision.";
        if (btn1Press)
        {
            Q8Ans = 0;
            btn1Press = false;
            totalScore = Q1Ans + Q2Ans + Q3Ans + Q4Ans + Q5Ans + Q6Ans + Q7Ans + Q8Ans;
            surveyComplete = true;
        }
        if (btn2Press)
        {
            Q8Ans = 1;
            btn2Press = false;
            totalScore = Q1Ans + Q2Ans + Q3Ans + Q4Ans + Q5Ans + Q6Ans + Q7Ans + Q8Ans;
            surveyComplete = true;
        }
        if (btn3Press)
        {
            Q8Ans = 2;
            btn3Press = false;
            totalScore = Q1Ans + Q2Ans + Q3Ans + Q4Ans + Q5Ans + Q6Ans + Q7Ans + Q8Ans;
            surveyComplete = true;
        }
        if (btn4Press)
        {
            Q8Ans = 3;
            btn4Press = false;
            totalScore = Q1Ans + Q2Ans + Q3Ans + Q4Ans + Q5Ans + Q6Ans + Q7Ans + Q8Ans;
            surveyComplete = true;
        }
        if (btn5Press)
        {
            Q8Ans = 4;
            btn5Press = false;
            totalScore = Q1Ans + Q2Ans + Q3Ans + Q4Ans + Q5Ans + Q6Ans + Q7Ans + Q8Ans;
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

    void Button5Press()             //same as above function 
    {
        btn5Press = true;
    }
}