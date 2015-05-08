## About

This is the repository for a mobile music game created in the MGDEV module 

## Requirements

- Unity 5 beta

## Set Up

1. Clone this repo: `git clone https://github.com/rix1/mgdev-life-of-pi.git` to any directory on your computer. 
2. Open Unity and select *Open other* option. 
3. Select the directory */path-to-cloned-repo/mgdev-life-of-pi/* and click open.
4. **In Unity:** Select `Menu > Assets > Sync MonoDevelop Project`. This will generate all the necessary files and sync up MonoDevelop.
5. **In Project View:** You should see a tab called "Project" with the different folders. Select the Scenes folder, and open `Stage 1`. 
5. Thats it! Play by pushing the play button in the Unity UI. Take a look at the different folders and their descriptions on how to organize the files below.


## Set up script editor

- On Windows, use Visual Studio.
- On OSX, you can either use Sublime (requires a bit of a set up) (http://wiki.unity3d.com/index.php/Using_Sublime_Text_as_a_script_editor)
- Or the new Visual Studio Code (requires the latest version of the Mono framework) (http://unreferencedinstance.com/how-to-integrate-visual-studio-code-with-unity3d-project/)

## Project structure

Only two folders should be kept under source control: Assets and ProjectSettings. Others are generated from these two. In your "Project" pane, you can find different types of assets:


**Prefabs**

Reusable game objects (ex: Bullets, enemies, bonuses).

Prefabs can be seen as a class in a programming language, which can be instantiated into game objects. It's a mold you can duplicate and change at will in the scene or during the game execution.


**Scenes**

A scene is basically a level or a menu.

Contrary to the other objects you create in the "Project" pane, scenes are created with the "File" menu. If you want to create a scene, click on the "New Scene" submenu, then do not forget to save it to the "Scenes" folder.

Scenes need to be manually saved. It's a classic mistake in Unity to make some changes to a scene and its elements and to forget to save it after. Your version control tool will not see any change until you scene is saved.


**Sounds**

It's pretty clear what goes in here.


**Scripts**

All the code goes here. We use this folder as the equivalent of a root folder in a C# project.


**Sprites**

Sprites are sprites and images of your game.


**Resources**

Resources is a useful and unique folder. It allows you to load an object or a file inside a script (using the static Resources class).


## Naming Conventions

I guess we have to figure this out as we go along, but as you can see in the /sprites/ folder, I will try to name the sprites according to where they are supposed to be used:

	Sprites/
		| - #_characters_map	// The # denotes "general" - *character* is a description
		|						and *map* implies that the image is a sprite sheet i.e. 
		|						contains multiple sprites.
		| - 1_bg_mountain		// *1* denotes the scene, *bg* is short for background,
		|	 						and *mountain* is a simple description.
		| - g1_button_map		// *g1* is short for game mode 1. 


### Additional information

Mastering Unity project folder structure - version control systems:
http://unity3d.com/learn/tutorials/modules/beginner/architecture/folders-in-version-control

2D Game in Unity tutorial:
http://pixelnest.io/tutorials/2d-game-unity/install-and-scene/