using UnityEngine;

public class LoadQuestionnaire : MonoBehaviour {

    public GameObject ARCam;
    public GameObject QuizPanel;

    public Transform quizManager;
    private QuizPopulator quizObj;

    private void Start()
    {
        quizObj = quizManager.GetComponent<QuizPopulator>();
    }

    // Disables animation and AR and loads the Quiz.
    public void Load()
    {
        Debug.Log("Loading");
        this.DisableAR();
        quizObj.NextQuestion();
    }

    private void DisableAR()
    {
        ARCam.gameObject.SetActive(false);
        QuizPanel.gameObject.SetActive(true);   
    }

}
