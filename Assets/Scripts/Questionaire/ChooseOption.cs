using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOption : MonoBehaviour {

    public string answerSelected;

    public void Chosen(string answer)
    {
        answerSelected = answer;
    }
}
