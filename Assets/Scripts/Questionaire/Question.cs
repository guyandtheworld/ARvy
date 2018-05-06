using UnityEngine;

[System.Serializable]
public class Question {
    [TextArea(3, 10)]
    public string question;
    public string[] answers = new string[4];
    public int rightAnswer;
}
