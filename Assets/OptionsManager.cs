using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsManager : MonoBehaviour {

    public string OptionSelected;

    public void OptionChosen()
    {
        TextMeshProUGUI answer = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        OptionSelected = answer.text;
        Debug.Log("Chosen Option is : " + OptionSelected);
    }

    public string GetSelectedOption()
    {
        return OptionSelected;
    }
}
