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
            Debug.Log(Answertext.isActiveAndEnabled);

            answerObject.SetParent(AnswerPanel);
        }
    }

    public void OptionSet()
    {
        Debug.Log("Option Set");
    }

    private void EndDialogue()
    {
        Debug.Log("End");
        throw new NotImplementedException();
    }
    
}
