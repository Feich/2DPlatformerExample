# 2DPlatformerExample
An example of a 2D platformer made with Unity.

2D platformer, as a genre of video games, has possibly the easiest to implement gameplay which makes it ideal as someone's first foray into game development. This project contains a couple of examples on how to implement gameplay typical of this genre in Unity.

## Implemented functionality
Functionality that can currently be found:
* A simple movement script, which DOES allow multiple consecutive jumps.
* A simple player controller. Contains all the functionality of the simple movement script and fixes the issue of allowing multiple consecutive jumps through the use of a state machine. This allows for the player character to be in only one state at a time.
* Level random generation, or to be more precise, faux random generation. Uses premade "blocks" to create a seamless, continuous level. This is done with the LevelGenerationController and ConnectionPointManager.

