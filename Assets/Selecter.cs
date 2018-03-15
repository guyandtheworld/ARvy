using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used as a connection for connecting the audio to the model swapper.
// The audio signals are received here and swap function is called.

public class Selecter : MonoBehaviour {

    private bool SwapModel = true;

    // For receiving audio from Watson.
    public GameObject audioWat;
    AudioStreaming audioStreamer;

    // For swapping models.
    public GameObject swapper;
    ModelSwapper modelSwapper;

    //Testing
    private System.Random rnd;
    private List<string> iList = new List<string>();

    public void resetSwapModel()
    {
        SwapModel = false;
    }

    // Use this for initialization
    void Start () {
        // Testing
        rnd = new System.Random();
        iList.Add("sphere");
        iList.Add("cube");

        audioStreamer = audioWat.GetComponent<AudioStreaming>();
        modelSwapper = swapper.GetComponent<ModelSwapper>();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 120, 40), "Swap Model"))
        {
            if (SwapModel)
                SwapModel = false;
            else
                SwapModel = true;
        }
    }

    // Update is called once per frame
    void Update () {

        // Randomly takes an item in the iList and displays it.
        if (SwapModel)
            modelSwapper.SwapModel((string)iList[rnd.Next(iList.Count)]);
    }
}
