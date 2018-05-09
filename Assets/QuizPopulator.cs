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


	// Use this for initialization
	void Start () {
        questionElement = QE.GetComponent<QuestionElement>();
        questionQueue.Clear();

        foreach (Question qna in questionElement.questions)
        {
            questionQueue.Enqueue(qna);
        }

        NextQuestion();
    }


    public void NextQuestion() {

        GetSelectedAnswer();

        // Disable all Option answers which are children.
        foreach (Transform child in AnswerPanel)
        {
            child.gameObject.SetActiveRecursively(false);
        }


        if (questionQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Gets Question object and sets Question.
        Question question = questionQueue.Dequeue();
        questionText.text = question.question;

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
        int count=0;
        foreach (Transform child in AnswerPanel)
        {
            if (child.gameObject.active)
            {
                count++;
            }
        }

        Debug.Log(count);
    }

    private void EndDialogue()
    {
        Debug.Log("End");
        throw new NotImplementedException();
    }
    
}
