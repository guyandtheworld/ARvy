using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ViewManager : MonoBehaviour {

    private Queue<string> sceneQ;
    
    private string CurrentScene = "0";

    public Scene scene;

    // Returns the currentScene story is on.
    public string GetCurrentScene()
    {
        return CurrentScene;
    }

    // Use this for initialization
    void Start () {
        sceneQ = new Queue<string>();
        for (int i = 0; i < scene.scenes.Length; i++)
        {
            sceneQ.Enqueue(scene.scenes[i]);
        }

        DisplayNextScene();
    }
    
    public void DisplayNextScene()
    {
        if (sceneQ.Count == 0)
        {
            EndScene();
            return;
        }

        CurrentScene = sceneQ.Dequeue();
    }
    
    void EndScene()
        {
            Debug.Log("End of conversation");
        }

    public void QuitStory()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
