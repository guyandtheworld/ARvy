using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDisplay : MonoBehaviour {

    public Text storyTitle;
    public Image storyCover;

    public Story story;

	void Start () {
        if (story != null) Initialize(story);
	}
	
    public void Initialize(Story story)
    {
        this.story = story;
        if (storyTitle != null)
            storyTitle.text = story.storyTitle;
        if (storyCover != null)
            storyCover.sprite = story.sprite;
    }
}
