using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used as a connection for connecting the audio to the model swapper.
// The audio signals are received here and swap function is called.

public class Selecter : MonoBehaviour {

    private bool swapModel = true;

    // For receiving audio from Watson.
    public GameObject audioWat;
    AudioStreaming audioStreamer;

    // For swapping models.
    public GameObject swapper;
    ModelSwapper modelSwapper;

    // For getting conversation details.
    public GameObject convo;
    ExampleConversation conversation;

    private string tempString;
    private string convString;

    // Use this for initialization
    void Start () {
        audioStreamer = audioWat.GetComponent<AudioStreaming>();
        modelSwapper = swapper.GetComponent<ModelSwapper>();
        conversation = convo.GetComponent<ExampleConversation>();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 120, 40), "Swap Model"))
        {
            conversation.dialogString("One summer’s day, in a field, a Grasshopper");
            if (swapModel)
            {
                modelSwapper.SwapModel("sphere");
                swapModel = false;
            }
            else
                swapModel = true;
        }
    }

    void SwapModelOnVoice()
    {        
        // Gets the string and compares its size and calls the conversation.    
        if (tempString != convString)
        {
            if (tempString.Split(' ').Length > 1)
            {
                convString = audioStreamer.GetString();
                // conversation.dialogString(convString);
                modelSwapper.SwapModel("cube");
            }
        }
    }

    // Update is called once per frame
    void Update () {
        tempString = audioStreamer.GetString();
        SwapModelOnVoice();
        if (conversation.returnResponse() != null)
        {
            string response = conversation.returnResponse().ToString();
            print(response);
            string[] tokens = response.Split(new[] { "output" }, System.StringSplitOptions.None);
            print(tokens[1].ToString()[12]);
            conversation.resetResponse();
        }
    }
}
