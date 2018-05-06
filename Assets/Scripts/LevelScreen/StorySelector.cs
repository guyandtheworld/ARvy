using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySelector : MonoBehaviour {

    // Used to fetch the name of the story from the tag
    // and loads the required story scene.
    public void StartStory()
    {
        string StoryName = gameObject.transform.tag;
        SceneManager.LoadScene(StoryName);
    }
}
