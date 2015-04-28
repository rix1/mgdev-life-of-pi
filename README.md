## About

This is the repository for a mobile music game created in the MGDEV module 


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





### Additional information

Mastering Unity project folder structure - version control systems:
http://unity3d.com/learn/tutorials/modules/beginner/architecture/folders-in-version-control

2D Game in Unity tutorial:
http://pixelnest.io/tutorials/2d-game-unity/install-and-scene/