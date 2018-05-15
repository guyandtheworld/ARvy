using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsManager : MonoBehaviour {

    public string OptionSelected;

    public Transform chooseOption;
    private ChooseOption chooseOptionObject;

    private void Start()
    {
        chooseOptionObject = chooseOption.GetComponent<ChooseOption>();
    }

    public void OptionChosen()
    {
        TextMeshProUGUI answer = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        OptionSelected = answer.text;
        chooseOptionObject.Chosen(OptionSelected);
    }
}
