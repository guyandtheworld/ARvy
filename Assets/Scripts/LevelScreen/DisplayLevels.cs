using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayLevels : MonoBehaviour {


    public Text title;
    public StorySelector storyButton;

    public List<Story> stories = new List<Story>();

	// Use this for initialization
	void Start () {
        prime(stories[0]);
	}

    void prime(Story story)
    {
        title.text = story.title;
        StorySelector button = (StorySelector)Instantiate(storyButton);
    }

    // Go back to the main menu.
    public void QuiteLevelScreen()
    {
        SceneManager.LoadScene("Menu");
    }

}
