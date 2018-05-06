using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour {

    // public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public Animator animatorTitle;

    private Queue<string> sentences;
    private Queue<string> scenes;

    public GameObject quiz;
    private LoadQuestionnaire loadQuestionnaire;

    private string CurrentScene = "0";

    // Returns the currentScene story is on.
    public string GetCurrentScene()
    {
        return CurrentScene;
    }

    // Use this for initialization
    void Start () {
        dialogueText.text = "";
        // nameText.text = "";
        sentences = new Queue<string>();
        scenes = new Queue<string>();
        loadQuestionnaire = quiz.GetComponent<LoadQuestionnaire>();
        
	}

    // Starts the conversation by appending scenes and 
    // sentences onto a queue
    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue.scenes.Length != dialogue.sentences.Length)
        {
            Debug.LogError("Some of sentences are not alloted scenes!");
        }

        animator.SetBool("IsOpen", true);
        animatorTitle.SetBool("TitleOpen", false);

        Debug.Log("Starting Dialogue " + dialogue.name);
        sentences.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            scenes.Enqueue(dialogue.scenes[i].ToString());
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
        CurrentScene = scenes.Dequeue();

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

            loadQuestionnaire.Load();
        }

    public void QuitStory()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
