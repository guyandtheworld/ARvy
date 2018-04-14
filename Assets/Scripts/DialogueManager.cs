using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    // public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public Animator animatorTitle;

    private Queue<string> sentences;

    // Use this for initialization
	void Start () {
        dialogueText.text = "";
        // nameText.text = "";
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        animatorTitle.SetBool("TitleOpen", false);
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
        {
            // The pop up will be removed.
            animator.SetBool("IsOpen", false);
            animatorTitle.SetBool("TitleOpen", true);
            Debug.Log("End of conversation");
        }
}
