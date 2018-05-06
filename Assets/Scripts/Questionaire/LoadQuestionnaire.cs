using UnityEngine;

public class LoadQuestionnaire : MonoBehaviour {

    public GameObject ARCam;
    public GameObject QuizPanel;


    // Disables animation and AR and loads the Quiz.
    public void Load()
    {
        Debug.Log("Loading");
        this.DisableAR();
    }

    private void DisableAR()
    {
        ARCam.gameObject.SetActive(false);
        QuizPanel.gameObject.SetActive(true);   
    }

}
