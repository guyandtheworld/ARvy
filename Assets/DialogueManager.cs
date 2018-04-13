using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    // public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    // Use this for initialization
	void Start () {
        dialogueText.text = "";
        // nameText.text = "";
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Dialogue " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;
    } 

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
