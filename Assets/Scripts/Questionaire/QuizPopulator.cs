using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class QuizPopulator : MonoBehaviour {

    public TextMeshProUGUI questionText;

    public Transform Answer;
    public Transform AnswerPanel;

    // Loads the Question Elements.
    public GameObject QE;
    private QuestionElement questionElement;

    // Queue for storing the Questions.
    private Queue<Question> questionQueue = new Queue<Question>();

    // Get the Chosen option.
    public Transform chooseOption;
    private ChooseOption chooseOptionObject;

    private Question question;

    // Point Manager
    public Transform points;
    private PointSystem pointsObject;

    // Use this for initialization
    void Start () {
        questionElement = QE.GetComponent<QuestionElement>();
        questionQueue.Clear();

        pointsObject = points.GetComponent<PointSystem>();

        foreach (Question qna in questionElement.questions)
        {
            questionQueue.Enqueue(qna);
        }

        // NextQuestion();
    }


    public void NextQuestion() {

        // Shouldn't run during the first iteration.
        if (questionQueue.Count < questionElement.questions.Count)
        {
            GetSelectedAnswer();
        }

        if (questionQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Disable all Option answers which are children.
        foreach (Transform child in AnswerPanel)
        {
            child.gameObject.SetActiveRecursively(false);
        }

        // Gets Question object and sets Question.
        question = questionQueue.Dequeue();
        questionText.text = question.question;

        Debug.Log(question.question);
        Debug.Log(question.answers.Length);

        // Sets options to children.
        foreach (string i in question.answers)
        {
            Transform answerObject = Instantiate(Answer);
            Transform answer = answerObject.Find("AnswerText");

            TextMeshProUGUI Answertext = answer.GetComponent<TextMeshProUGUI>();

            Answertext.SetText(i);

            answerObject.SetParent(AnswerPanel);
        }

    }

    public void GetSelectedAnswer()
    {
        string[] answers = question.answers;
        int rightAnswerOption = question.rightAnswer;

        string RightAnswer = answers[rightAnswerOption];

        chooseOptionObject = chooseOption.GetComponent<ChooseOption>();
        string ChosenAnswer = chooseOptionObject.answerSelected;

        if (ChosenAnswer == RightAnswer)
        {
            pointsObject.Scored();
        }
        else { 
            Debug.Log("Wrong Answer! No Points");
        }

    }

    private void EndDialogue()
    {
        Debug.Log("End");
        throw new NotImplementedException();
    }
    
}
