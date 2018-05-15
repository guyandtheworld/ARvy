using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour {

    private int Score;
    public TextMeshProUGUI ScoreText;

	// Use this for initialization
	void Start () {
        Score = PlayerPrefs.GetInt("TotalScore");
        ScoreText.SetText(Score.ToString());
    }

    public void Scored()
    {
        Score += 10;
        ScoreText.SetText(Score.ToString());
        PlayerPrefs.SetInt("TotalScore", Score);
    }
}
