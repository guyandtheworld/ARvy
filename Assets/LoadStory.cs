using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStory : MonoBehaviour {

    public ScrollSnapRect scrollSnapRect;

    private Object[] scenes;

    private void Start()
    {
        scenes = Resources.LoadAll("ARStories", typeof(Scene));
        foreach (Scene scene in scenes)
        {
            Scene sceneObj = Instantiate(scene);
            sceneObj.transform.parent = gameObject.transform;
        }
    }

    public void StopSceneAndLoadSelectedStory()
        {
            string sceneName = scrollSnapRect.getCurrentScene();
            if (sceneName != null) {
                SceneManager.LoadScene(sceneName);
            }

        }
}
