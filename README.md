# ARvy

<img src="https://media.giphy.com/media/OQH8Jb5phYdg8lyQAT/giphy.gif" width="800" height="400" />

# ARvy

ARvy is a prototype AR app that redefined storytelling for kids. Conventional story-telling is a one way street. Kids can only imagine what happens and there is no alternate ending, where in fact they could flex their imagination to make something bigger than happen in-front of their eyes. We thought that was severly limiting the imagination and we knew AR had the potential to change that. What if you could control what happens in the story, wouldn't that be more impactful than conventional one-directional story-telling?

ARvy app was cross-platform compatible and worked on both iOS and Android. From the start screen you could select from what all stories you wanted to play, we had built 5 stories. After hitting the play button, all you had to do was point it at a flat surface where we used Vuforia's ground-plane technology to detect the floor and project the "scene", which was a scaled 2D plane where the animation could be augmented to that surface and after that we could interact and view the story from multiple angles. You could view and pause scenes, go back, interact with the characters in the stories.

## Implementation

### Application
The application was built in Unity itself due to the flexibility offered by the Unity game engine. The physics was similar to that of making a conventional game and the game-mechanics for AR remained largely unchanged. Also due to the support Unity offered due to the cross-platform compatibility for iOS/Android and the ease of getting started, Unity was what we chose to go along with.

### Creative Content
Creative content like the models like the characters, animations were done on Blender and all the scenes were put together within Unity.

The models were built using Blender and animations were put together in Unity itself. 

### Augmented Content
Initially we created the prototype using the [Vuforia](https://www.vuforia.com/) framework due to its ground-plane technology. But at the time of making the prototype, Google released its [ARCore](https://developers.google.com/ar/) framework which had much more of a smoother integration with the native android software and provided  more flexibility than the Vuforia framework, it was also cross-platform compatible and was much more easier to use.
